using RabbitMq.Demo.Business.Abstractions;
using RabbitMq.Demo.Service.Abstractions;
using RabbitMq.Shared.Constants;
using RabbitMq.Shared.Providers.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Demo.Business.Implementations
{
    public class BoredBusiness : BusinessBase, IBoredBusiness
    {
        public BoredBusiness(ICoreProvider coreProvider, IRabbitMQService rabbitMQService) : base(coreProvider, rabbitMQService)
        {
        }
        public void Consumer(object? e)
        {
            _coreProvider.LogInformation("BoredConsumer", e);
        }

        public async Task ConsumerAsync(object? e)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10 * 1000);
            });
            _coreProvider.LogInformation("BoredConsumer", e);
        }

        public async Task GetAndPublishMessage(string exchange = ExchangeName.Topic)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(GetPublicAPI.BoredAPI);
            if (response != null)
            {
                var contents = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response at {GetPublicAPI.BoredAPI}: {contents}");
                _rabbitMQService.Publish("asdasd", RabbitMQQueueName.Demo, exchange, RabbitMQKey.DemoTopic);
                //_rabbitMQService.Publish(contents, RabbitMQQueueName.Demo2, exchange, RabbitMQKey.DemoTopic);
            }
            else
            {
                Console.WriteLine($"Response at {GetPublicAPI.BoredAPI} is null");
            }
        }
    }
}
