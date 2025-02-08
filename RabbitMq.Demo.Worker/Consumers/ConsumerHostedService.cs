namespace RabbitMq.Demo.Worker.Consumers
{
    public class ConsumerHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ConsumerHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var type in GetType().Assembly.GetTypes().Where(type => type.IsClass
            && !type.IsAbstract && type.IsSubclassOf(typeof(ConsumerBase))))
            {
                _serviceProvider.GetRequiredService(type);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
