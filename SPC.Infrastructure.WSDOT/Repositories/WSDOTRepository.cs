using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SPC.Infrascructure.WSDOT.Repositories.Interfaces;
using SPC.Infrascructure.Utilities;

namespace SPC.Infrascructure.WSDOT.Repositories;

public class WSDOTRepository : IWSDOTRepository
{

    private string _wsdotApiAccessCode = AzureUtilities.GetEnvironmentVariable("WSDOT_API_ACCESS_CODE");

    private readonly ILogger<WSDOTRepository> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _memoryCache;

    private const int CACHE_DURATION_MINUTES = 5;

    public WSDOTRepository(ILogger<WSDOTRepository> logger,
        IHttpClientFactory httpClientFactory,
        IMemoryCache memoryCache)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _memoryCache = memoryCache;
    }

    public async Task<IActionResult> GetMountainPassConditionAsync(string id)
    {
        string CACHE_KEY = "WSDOT_Pass_Conditions_" + id;

        try
        {
            if (_memoryCache.TryGetValue(CACHE_KEY, out string cachedData))
            {
                _logger.LogInformation("Returning cached WSDOT Mountain Pass conditions.");
                return new OkObjectResult(cachedData);
            }

            string apiUrl = $"https://wsdot.wa.gov/Traffic/api/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionAsJon?AccessCode={_wsdotApiAccessCode}&PassConditionID={id}";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    // Cache the successful response
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(CACHE_DURATION_MINUTES));

                    _memoryCache.Set(CACHE_KEY, jsonData, cacheOptions);

                    _logger.LogInformation("Fetched and cached WSDOT Mountain Pass conditions.");

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


    public async Task<IActionResult> GetCamerasAsync(string stateRoute,
        string startingMilepost,
        string endingMilepost)
    {
        string CACHE_KEY = "WSDOT_Pass_Conditions_" + stateRoute;

        try
        {
            if (_memoryCache.TryGetValue(CACHE_KEY, out string cachedData))
            {
                _logger.LogInformation("Returning cached WSDOT Cameras.");
                return new OkObjectResult(cachedData);
            }

            string apiUrl = $"https://wsdot.wa.gov/Traffic/api/HighwayCameras/HighwayCamerasREST.svc/SearchCamerasAsJson?AccessCode={_wsdotApiAccessCode}&StateRoute={stateRoute}&StartingMilepost={startingMilepost}&EndingMilepost={endingMilepost}";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    // Cache the successful response
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(CACHE_DURATION_MINUTES));

                    _memoryCache.Set(CACHE_KEY, jsonData, cacheOptions);

                    _logger.LogInformation("Fetched and cached WSDOT Cameras.");

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
