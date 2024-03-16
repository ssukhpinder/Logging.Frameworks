using Logging.Frameworks.NLog.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Frameworks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _serilogLogger;
        private readonly ILoggerManager _nLogLogger;

        public WeatherForecastController(ILogger<WeatherForecastController> serilogLogger, ILoggerManager nLogLogger)
        {
            _serilogLogger = serilogLogger;
            _nLogLogger = nLogLogger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _nLogLogger.LogInfo("Here is info message from the controller.");
            _nLogLogger.LogDebug("Here is debug message from the controller.");
            _nLogLogger.LogWarn("Here is warn message from the controller.");
            _nLogLogger.LogError("Here is error message from the controller.");


            _serilogLogger.LogInformation("Requesting Weather Forecast Details...");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
