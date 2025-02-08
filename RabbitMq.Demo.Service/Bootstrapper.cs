using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Demo.Service.Abstractions;
using RabbitMq.Demo.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Demo.Service
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQService, RabbitMQService>();
        }
    }
}
