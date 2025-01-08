using Microsoft.AspNetCore.Mvc;

namespace eConstruction.Service.Notification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Notification-Freezing",
            "Notification-Bracing",
            "Notification-Chilly",
            "Notification-Cool",
            "Notification-Mild",
            "Notification-Warm",
            "Notification-Balmy",
            "Notification-Hot",
            "Notification-Sweltering",
            "Notification-Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNotificationWeatherForecast")]
        public IEnumerable<WeatherForecast> GetNotificationWeatherForecast()
        {
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
