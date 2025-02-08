using RabbitMq.Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Shared.Providers.Abstractions
{
    public interface ICoreProvider
    {
        Setting Setting { get; }
        void LogInformation(string message, object? data = null, [CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0);
    }
}
