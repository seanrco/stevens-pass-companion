using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SPC.Infrascructure.NOAA.Repositories.Interfaces;

namespace SPC.Infrascructure.NOAA.Repositories;

public class NOAARepository : INOAARepository
{

    private readonly ILogger<NOAARepository> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _memoryCache;

    private const string CACHE_KEY_NOAA_FORECAST = "NOAA_Forecast";
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

    public async Task<IActionResult> GetActiveAlerts()
    {
        try
        {
            if (_memoryCache.TryGetValue(CACHE_KEY_NOAA_ACTIVE_ALERTS, out string cachedData))
            {
                _logger.LogInformation("Returning cached NOAA alerts");
                return new OkObjectResult(cachedData);
            }

            string url = "https://api.weather.gov/alerts/active?point=47.7462%2C-121.0859";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

            HttpResponseMessage? response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    // Cache the successful response
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(CACHE_DURATION_MINUTES));

                    _memoryCache.Set(CACHE_KEY_NOAA_ACTIVE_ALERTS, jsonData, cacheOptions);

                    _logger.LogInformation("Fetched and cached new NOAA alerts");

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
            if (_memoryCache.TryGetValue(CACHE_KEY_NOAA_FORECAST, out string cachedData))
            {
                _logger.LogInformation("Returning cached NOAA forecast");
                return new OkObjectResult(cachedData);
            }

            string url = "https://api.weather.gov/gridpoints/OTX/25,115/forecast";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

            HttpResponseMessage? response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    // Cache the successful response
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(CACHE_DURATION_MINUTES));

                    _memoryCache.Set(CACHE_KEY_NOAA_FORECAST, jsonData, cacheOptions);

                    _logger.LogInformation("Fetched and cached new NOAA forecast");

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
