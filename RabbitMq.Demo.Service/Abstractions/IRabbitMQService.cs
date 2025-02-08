using RabbitMq.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Demo.Service.Abstractions
{
    public interface IRabbitMQService
    {
        void Publish<T>(T body, string queue, string exchange, string routingKey, BaseQueueRequest<T>? request = null);
    }
}
