using System.Net.Http.Json;
using System.Text.Json;
using SPC.Client.Models.NOAA.ActiveAlerts;
using SPC.Client.Models.NOAA.Forecast;

namespace SPC.Client.Services;

public class NOAAService
{

    private readonly ILogger<NOAAService> _logger;
    private readonly HttpClient _httpClient;

    public NOAAService(ILogger<NOAAService> logger,
        HttpClient httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory;
    }

    public async Task<NOAAActiveAlerts?> GetActiveAlertsAsync()
    {
        try
        {
            var result = await _httpClient.GetAsync("/api/NOAA/GetActiveAlerts");

            if (result.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await _httpClient.GetFromJsonAsync<NOAAActiveAlerts>("/api/NOAA/GetActiveAlerts", options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return null;
    }

    public async Task<NOAAForecast?> GetForecastAsync()
    {
        try
        {
            var result = await _httpClient.GetAsync("/api/NOAA/GetForecast");

            if (result.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await _httpClient.GetFromJsonAsync<NOAAForecast>("/api/NOAA/GetForecast", options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return null;
    }


}