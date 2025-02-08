using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Settings
{
    public class RabbitMQSetting
    {
        public string? HostName { get; set; }
        public int Port { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? VirtualHost { get; set; }
        public string? ServerName { get; set; }
        public string? Uri { get; set; }
    }
}
