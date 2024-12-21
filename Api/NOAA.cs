using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Api;

public class NOAA
{

    private readonly HttpClient _httpClient;
    private readonly ILogger<NOAA> _logger;

    public NOAA(ILogger<NOAA> logger, 
        HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    [Function("NOAA")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "NOAA/GetReport")] HttpRequest req)
    {
        try
        {
            string url = "https://api.weather.gov/gridpoints/OTX/25,115/forecast";

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

            HttpResponseMessage? response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await _httpClient.GetStringAsync(url);

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return new OkObjectResult(jsonData);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return new OkObjectResult("Error calling api.");
    }
}
