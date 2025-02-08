using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Requests
{
    public class BaseQueueRequest<T>
    {
        //public IdentityInfo Identity { get; set; }
        public T Data { get; set; } = default(T)!;
        public int RetryCount { get; set; }
    }
}
