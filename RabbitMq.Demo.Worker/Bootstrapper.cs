using RabbitMq.Demo.Worker.Consumers;

namespace RabbitMq.Demo.Worker
{
    public static class Bootstrapper
    {
        public static void RegisterConsumers(this IServiceCollection services)
        {
            services.AddSingleton<TopicConsumer>();
            services.AddSingleton<Topic2Consumer>();
        }
    }
}
