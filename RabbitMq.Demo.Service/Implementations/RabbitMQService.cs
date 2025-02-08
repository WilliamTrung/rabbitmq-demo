using RabbitMq.Demo.Service.Abstractions;
using RabbitMq.Shared.Constants;
using RabbitMq.Shared.Extensions;
using RabbitMq.Shared.Providers.Abstractions;
using RabbitMq.Shared.Providers.Implementations;
using RabbitMq.Shared.Requests;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Demo.Service.Implementations
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IModel _model;
        private readonly ICoreProvider _coreProvider;
        public RabbitMQService(IRabbitMQProvider rabbitMQProvider, ICoreProvider coreProvider)
        {
            _model = rabbitMQProvider.Model;
            _coreProvider = coreProvider;
        }


        public void Publish<T>(T body, string queue, string exchange, string routingKey, BaseQueueRequest<T>? request = null)
        {
            var isSend = false;

            if (request is null)
            {
                request = new BaseQueueRequest<T>()
                {
                    Data = body
                };
                isSend = true;
            }
            else if (request.RetryCount < _coreProvider.Setting.MaxQueueRetryCount)
            {
                isSend = true;
                request.RetryCount++;
            }

            if (isSend)
            {
                _model.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                if (exchange == ExchangeType.Topic)
                {
                    _model.ExchangeDeclare(exchange: "topic", type: ExchangeType.Topic);
                    _model.QueueBind(queue, "topic", routingKey);//"*.*.topic");
                }
                else if (exchange == ExchangeType.Fanout)
                {
                    _model.ExchangeDeclare(exchange: "fanout", type: ExchangeType.Fanout);
                    _model.QueueBind(queue, "fanout", "");
                }
                else if (exchange == ExchangeType.Direct)
                {
                    _model.ExchangeDeclare(exchange: "direct", type: ExchangeType.Direct);
                    _model.QueueBind(queue, "direct", "direct");
                }
                var data = Encoding.UTF8.GetBytes(request.TrySerializeObject());
                _coreProvider.LogInformation($"Publish to RabbitMQ - queue: {queue}");
                _model.BasicPublish(exchange: exchange,
                         routingKey: routingKey,
                         basicProperties: null,
                         body: data);
            }
        }
    }
}
