using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPC.Api.Repository.Interfaces;

namespace SPC.Api.Repository;

public class NOAARepository : INOAARepository
{

    private readonly ILogger<NOAARepository> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public NOAARepository(ILogger<NOAARepository> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> GetActiveAlerts()
    {
        try
        {
            string url = "https://api.weather.gov/alerts/active?point=47.7462%2C-121.0859&limit=5";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

            HttpResponseMessage? response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return new OkObjectResult(jsonData);
                }
                else
                {
                    return new NoContentResult();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return new NoContentResult();
    }

    public async Task<IActionResult> GetForecast()
    {
        try
        {
            string url = "https://api.weather.gov/gridpoints/OTX/25,115/forecast";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

            HttpResponseMessage? response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return new OkObjectResult(jsonData);
                }
                else
                {
                    return new NoContentResult();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return new NoContentResult();
    }


}
