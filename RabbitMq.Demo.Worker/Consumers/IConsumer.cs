using RabbitMQ.Client.Events;

namespace RabbitMq.Demo.Worker.Consumers
{
    public interface IConsumer
    {
        void Handle(object sender, BasicDeliverEventArgs e);
    }
}
