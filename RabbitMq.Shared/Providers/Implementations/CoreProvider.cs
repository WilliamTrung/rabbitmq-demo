using Microsoft.Extensions.Options;
using RabbitMq.Shared.Extensions;
using RabbitMq.Shared.Providers.Abstractions;
using RabbitMq.Shared.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Providers.Implementations
{
    public class CoreProvider : ICoreProvider
    {
        public Setting Setting { get; }
        public CoreProvider(IOptions<Setting> setting)
        {
            Setting = setting.Value;
        }

        public void LogInformation(string message, object? data = null, [CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            var logInfo = new List<string>()
            {
                $"file: {Path.GetFileNameWithoutExtension(filePath)}",
                $"method: {methodName}",
                $"line: {lineNumber}",
                $"message: {message}"
            };

            if (data is not null)
            {
                logInfo.Add($"data: {data.TrySerializeObject()}");
            }

            var logMessage = string.Join("\n", logInfo);
            Console.WriteLine(logMessage);
        }
    }
}
