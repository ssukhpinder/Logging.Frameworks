
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Frameworks.ElmahIO.Extensions
{
    public static class ElmahHandlerExtension
    {
        public static IServiceCollection UseElmahHandler(this IServiceCollection services)
        {
            services.AddElmahIo(options =>
            {
                options.ApiKey = "API_KEY";
                options.LogId = new Guid("LOG_ID");
            });

            return services;
        }
    }
}
