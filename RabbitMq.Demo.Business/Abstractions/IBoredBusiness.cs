using RabbitMq.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Demo.Business.Abstractions
{
    public interface IBoredBusiness : IBusiness
    {
        Task GetAndPublishMessage(string exchange = ExchangeName.Topic);
        void Consumer(object? e);
        Task ConsumerAsync(object? e);
    }
}
