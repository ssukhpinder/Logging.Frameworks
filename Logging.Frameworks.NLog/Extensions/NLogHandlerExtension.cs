using Logging.Frameworks.NLog.Contracts;
using Logging.Frameworks.NLog.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Logging.Frameworks.NLog.Extensions
{
    public static class NLogHandlerExtension
    {
        public static WebApplicationBuilder UseNLogHandler(this WebApplicationBuilder builder, string handler)
        {

            // NLog: Setup NLog for Dependency injection
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

            return builder;
        }
    }
}
