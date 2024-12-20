using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class WeatherForecast
    {
        private readonly ILogger<WeatherForecast> _logger;

        public WeatherForecast(ILogger<WeatherForecast> logger)
        {
            _logger = logger;
        }

        [Function("WeatherForecast")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
