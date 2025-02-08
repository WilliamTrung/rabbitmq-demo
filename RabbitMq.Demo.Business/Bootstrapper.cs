using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Demo.Business.Abstractions;
using RabbitMq.Demo.Business.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Demo.Business
{
    public static class Bootstrapper
    {
        public static void RegisterBusinesses(this IServiceCollection services)
        {
            services.AddScoped<IBoredBusiness, BoredBusiness>();
        }
    }
}
