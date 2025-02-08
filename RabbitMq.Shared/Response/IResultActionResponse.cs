using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Response
{
    public interface IResultActionResponse<T>
    {
        T Data { get; set; }
    }

    public class ActionResponse
    {
        public bool IsSucceeded { get; set; }
    }

    public class ActionResponse<T> : ActionResponse, IResultActionResponse<T>
    {
        public T Data { get; set; } = default(T)!;
    }
}
