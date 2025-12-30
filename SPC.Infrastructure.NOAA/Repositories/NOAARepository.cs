using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SPC.Application.Repositories.Interfaces;
using SPC.Domain.Models.NOAA.ActiveAlerts;
using SPC.Domain.Models.NOAA.Forecast;
using SPC.Infrastructure.NOAA.Mappers;
using SPC.Infrastructure.NOAA.Models.ActiveAlerts;
using SPC.Infrastructure.NOAA.Models.Forecast;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SPC.Infrascructure.NOAA.Repositories;

public class NOAARepository : INOAARepository
{

    private readonly ILogger<NOAARepository> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _memoryCache;

    private const string USER_AGENT = "StevensPassCompanionApp";
    private const string CACHE_KEY_NOAA_ACTIVE_ALERTS = "NOAA_ActiveAlerts";
    private const int CACHE_DURATION_MINUTES = 5;

    public NOAARepository(ILogger<NOAARepository> logger,
        IHttpClientFactory httpClientFactory,
        IMemoryCache memoryCache)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _memoryCache = memoryCache;
    }

    public async Task<NOAAActiveAlerts> GetActiveAlerts()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true
            };

            if (_memoryCache.TryGetValue(CACHE_KEY_NOAA_ACTIVE_ALERTS, out string cachedData))
            {
                _logger.LogInformation("Returning cached NOAA alerts");
                var cachedDto = JsonSerializer.Deserialize<NOAAActiveAlertsDto>(cachedData, options);
                if (cachedDto == null) return null;
                return cachedDto?.ToDomain();
            }

            string url = "https://api.weather.gov/alerts/active?point=47.7462%2C-121.0859";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);

            HttpResponseMessage? response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;
            
            string jsonData = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(jsonData)) return null;

            // Cache the successful response
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(CACHE_DURATION_MINUTES));

            _memoryCache.Set(CACHE_KEY_NOAA_ACTIVE_ALERTS, jsonData, cacheOptions);

            _logger.LogInformation("Fetched and cached new NOAA alerts");

            var dto = JsonSerializer.Deserialize<NOAAActiveAlertsDto>(jsonData, options);

            if (dto == null) return null;

            return dto?.ToDomain();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ex.StackTrace);
            return null;
        }
    }

    public async Task<NOAAForecast> GetForecast(string latitude, string longitude)
    {
        try
        {
            string CACHE_KEY_NOAA_FORECAST = $"NOAA_Forecast_{latitude}_{longitude}";

            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true
            };

            if (_memoryCache.TryGetValue(CACHE_KEY_NOAA_FORECAST, out string cachedData))
            {
                _logger.LogInformation("Returning cached NOAA forecast");
                var cachedDto = JsonSerializer.Deserialize<NOAAForecastDto>(cachedData, options);
                if (cachedDto == null) return null;
                return cachedDto?.ToDomain();
            }

            string url = $"https://api.weather.gov/gridpoints/OTX/{latitude},{longitude}/forecast";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);

            HttpResponseMessage? response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            string jsonData = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(jsonData)) return null;

            // Cache the successful response
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(CACHE_DURATION_MINUTES));

            _memoryCache.Set(CACHE_KEY_NOAA_FORECAST, jsonData, cacheOptions);

            _logger.LogInformation("Fetched and cached new NOAA forecast");

            var dto = JsonSerializer.Deserialize<NOAAForecastDto>(jsonData, options);

            if (dto == null) return null;

            return dto?.ToDomain();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ex.StackTrace);
            return null;
        }
    }


}
