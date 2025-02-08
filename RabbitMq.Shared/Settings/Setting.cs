using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Settings
{
    public class Setting
    {
        public RabbitMQSetting RabbitMQ { get; set; } = null!;
        public int MaxQueueRetryCount { get; set; }
    }
}
