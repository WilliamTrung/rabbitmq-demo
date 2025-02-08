using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Constants
{
    public static class ExchangeName
    {
        public const string Topic = "topic";
        public const string Fanout = "fanout";
        public const string Direct = "direct";
    }
    public static class GetPublicAPI
    {
        public const string BoredAPI = "https://www.boredapi.com/api/activity";
    }
    public static class RabbitMQKey
    {
        public const string DemoTopic = "RabbitMq.Demo.topic";
        public const string DemoFanout = "";
        public const string DemoDirect = "RabbitMq.Demo.direct";
    }

    public static class RabbitMQQueueName
    {
        public const string Demo = "trung";
        public const string Demo2 = "dai";
    }
}
