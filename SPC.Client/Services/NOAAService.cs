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
            HttpResponseMessage response = await _httpClient
                .GetAsync("/api/NOAA/GetActiveAlerts");

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<NOAAActiveAlerts?>(jsonData, options);
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
            HttpResponseMessage response = await _httpClient
                .GetAsync("/api/NOAA/GetForecast");

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<NOAAForecast?>(jsonData, options);
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