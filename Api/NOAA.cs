using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Api
{
    public class NOAA
    {

        public readonly string NOAA_SP_API_URL = "https://api.weather.gov/gridpoints/OTX/25,115/forecast";

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger<NOAA> _logger;

        public NOAA(ILogger<NOAA> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [Function("NOAA/GetForecast")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                HttpClient? httpClient = _httpClientFactory.CreateClient();

                httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

                HttpResponseMessage? response = await httpClient.GetAsync(NOAA_SP_API_URL);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await httpClient.GetStringAsync(NOAA_SP_API_URL);

                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        return new OkObjectResult(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("NOAAService.GetForecastAsync - Error - " + ex.Message + ex.StackTrace);
            }

            return new OkObjectResult("N/A");
        }
    }
}
