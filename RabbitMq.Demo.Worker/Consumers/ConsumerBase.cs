using RabbitMq.Shared.Providers.Abstractions;
using RabbitMq.Shared.Providers.Implementations;
using RabbitMq.Shared.Requests;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMq.Shared.Extensions;
using System.Text;

namespace RabbitMq.Demo.Worker.Consumers
{
    public abstract class ConsumerBase : IConsumer
    {
        protected readonly IServiceProvider _serviceProvider;

        protected abstract string Queue { get; }
        protected abstract string RoutingKey { get; }
        protected abstract string Exchange { get; }
        //protected abstract string ExchangeName { get; }
        protected ConsumerBase(IRabbitMQProvider rabbitMQProvider,
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var model = rabbitMQProvider.Model;
            var consumer = new EventingBasicConsumer(model);
            consumer.Received += Handle;
            model.QueueDeclare(queue: Queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            Console.WriteLine($"Exchange: {Exchange}");
            model.ExchangeDeclare(exchange: Exchange, type: Exchange);
            model.QueueBind(Queue, Exchange, routingKey: Exchange == ExchangeType.Fanout ? string.Empty : RoutingKey);
            model.BasicConsume(queue: Queue, autoAck: true, consumer: consumer);

        }

        public abstract void Handle(object? sender, BasicDeliverEventArgs e);

        protected (ICoreProvider, BaseQueueRequest<T>) GetData<T>(IServiceScope scope, BasicDeliverEventArgs e)
        {
            var body = Encoding.UTF8.GetString(e.Body.ToArray()).TryDeserializeObject<BaseQueueRequest<T>>();
            var coreProvider = scope.ServiceProvider.GetRequiredService<ICoreProvider>();
            //coreProvider.LogInformation($"Receive from RabbitMQ - queue: {Queue}", body);
            return (coreProvider, body);
        }
    }
}
