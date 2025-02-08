using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Providers.Abstractions
{
    public interface IRabbitMQProvider
    {
        ConnectionFactory Factory { get; }
        IConnection Connection { get; }
        IModel Model { get; }

    }
}
