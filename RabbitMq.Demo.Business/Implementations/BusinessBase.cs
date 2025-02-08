using RabbitMq.Demo.Business.Abstractions;
using RabbitMq.Demo.Service.Abstractions;
using RabbitMq.Shared.Providers.Abstractions;
using RabbitMq.Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Demo.Business.Implementations
{
    public class BusinessBase : IBusiness
    {
        protected readonly ICoreProvider _coreProvider;
        protected readonly Setting _setting;
        protected readonly IRabbitMQService _rabbitMQService;
        public BusinessBase(ICoreProvider coreProvider, IRabbitMQService rabbitMQService)
        {
            _setting = coreProvider.Setting;
            _coreProvider = coreProvider;
            _rabbitMQService = rabbitMQService;
        }
    }
}
