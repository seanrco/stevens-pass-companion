using SPC.Client.Models.NOAA;
using System.Net.Http.Json;
using System.Text.Json;

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

    public async Task<NOAAStevensPassForecast?> GetForecastAsync()
    {
        try
        {
            var result = await _httpClient.GetAsync("/api/NOAA/GetReport");

            if (result.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await _httpClient.GetFromJsonAsync<NOAAStevensPassForecast>("/api/NOAA/GetReport", options);
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