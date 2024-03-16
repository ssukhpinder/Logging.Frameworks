using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Logging.Frameworks.Serilog.Extensions
{
    public static class SeriLogHandlerExtension
    {
        public static WebApplicationBuilder UseSeriLogHandler(this WebApplicationBuilder builder, string handler)
        {
            IConfiguration configurationBase = new ConfigurationBuilder()
                .AddJsonFile(string.Concat(Directory.GetCurrentDirectory(), handler, "\\appsettings.json"))
                .Build();


            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(configurationBase));

            return builder;
        }
    }
}
