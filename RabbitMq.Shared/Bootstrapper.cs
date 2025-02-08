using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Shared.Providers.Abstractions;
using RabbitMq.Shared.Providers.Implementations;
using RabbitMq.Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared
{
    public static class Bootstrapper
    {
        public static void RegisterProviders(this IServiceCollection services)
        {
            services.AddScoped<ICoreProvider, CoreProvider>();
            services.AddSingleton<IRabbitMQProvider, RabbitMQProvider>();
        }
        public static void RegisterConfigOptions(this IServiceCollection services, in Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.Configure<Setting>(configuration.GetSection("Setting"));
        }
    }
}
