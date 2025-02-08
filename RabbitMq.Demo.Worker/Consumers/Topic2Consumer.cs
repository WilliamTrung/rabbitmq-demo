using RabbitMq.Demo.Business.Abstractions;
using RabbitMq.Demo.Service.Abstractions;
using RabbitMq.Shared.Constants;
using RabbitMq.Shared.Providers.Abstractions;
using RabbitMq.Shared.Providers.Implementations;
using RabbitMq.Shared.Requests;
using RabbitMQ.Client.Events;

namespace RabbitMq.Demo.Worker.Consumers
{
    public class Topic2Consumer : ConsumerBase, IConsumer
    {
        public Topic2Consumer(IRabbitMQProvider rabbitMQProvider, IServiceProvider serviceProvider) : base(rabbitMQProvider, serviceProvider)
        {
        }

        protected override string Queue => RabbitMq.Shared.Constants.RabbitMQQueueName.Demo;

        protected override string RoutingKey => RabbitMq.Shared.Constants.RabbitMQKey.DemoTopic;

        protected override string Exchange => ExchangeName.Topic;

        public override async void Handle(object? sender, BasicDeliverEventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();
            ICoreProvider? coreProvider = null;
            BaseQueueRequest<object>? baseQueueRequest = null;
            try
            {
                var (provider, request) = GetData<object>(scope, e);
                coreProvider = provider;
                baseQueueRequest = request;
                var business = scope.ServiceProvider.GetRequiredService<IBoredBusiness>();
                Console.WriteLine("\n\tTopic2Consumer");
                business.Consumer(request);
            }
            catch (Exception ex)
            {
                coreProvider.LogInformation($"{ex}");
                var rabbitMQService = scope.ServiceProvider.GetRequiredService<IRabbitMQService>();
                rabbitMQService.Publish(null, Queue, Exchange, RoutingKey, baseQueueRequest);
            }
        }
    }
}
