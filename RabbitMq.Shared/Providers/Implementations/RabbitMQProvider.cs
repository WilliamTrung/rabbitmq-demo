using Microsoft.Extensions.Options;
using RabbitMq.Shared.Providers.Abstractions;
using RabbitMq.Shared.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Providers.Implementations
{
    public class RabbitMQProvider : IRabbitMQProvider
    {
        public ConnectionFactory Factory { get; }
        public IConnection Connection { get; }
        public IModel Model { get; }
        public RabbitMQProvider(IOptions<Setting> settingOptions)
        {
            var setting = settingOptions.Value;
            Factory = new ConnectionFactory()
            {
                UserName = setting.RabbitMQ.UserName,
                Password = setting.RabbitMQ.Password,
                VirtualHost = setting.RabbitMQ.VirtualHost
            };

            if (!string.IsNullOrWhiteSpace(setting.RabbitMQ.Uri))
            {
                Factory.Uri = new Uri(setting.RabbitMQ.Uri);
                Factory.Ssl = new SslOption()
                {
                    Enabled = true,
                    ServerName = setting.RabbitMQ.ServerName
                };
            }
            else
            {
                Factory.HostName = setting.RabbitMQ.HostName;
                Factory.Port = setting.RabbitMQ.Port;
            }

            Connection = Factory.CreateConnection();
            Model = Connection.CreateModel();
        }
    }
}
