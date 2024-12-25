using Api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Repository;

public class WSDOTRepository : IWSDOTRepository
{

    // TODO - How can we remove access code from code for local dev?
    private readonly string _wsdotApiAccessCode = Environment.GetEnvironmentVariable("WSDOT_API_ACCESS_CODE")
    ?? "0359523e-015e-4244-9e73-cd932eb44542";

    private readonly ILogger<WSDOTRepository> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public WSDOTRepository(ILogger<WSDOTRepository> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> GetMountainPassConditionAsync(string id)
    {
        try
        {
            string apiUrl = $"https://wsdot.wa.gov/Traffic/api/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionAsJon?AccessCode={_wsdotApiAccessCode}&PassConditionID={id}";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await httpClient.GetStringAsync(apiUrl);

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

        return new NoContentResult();
    }


    public async Task<IActionResult> GetCamerasAsync(string stateRoute, 
        string startingMilepost, 
        string endingMilepost)
    {
        try
        {
            string apiUrl = $"https://wsdot.wa.gov/Traffic/api/HighwayCameras/HighwayCamerasREST.svc/SearchCamerasAsJson?AccessCode={_wsdotApiAccessCode}&StateRoute={stateRoute}&StartingMilepost={startingMilepost}&EndingMilepost={endingMilepost}";

            HttpClient? httpClient = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await httpClient.GetStringAsync(apiUrl);

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

        return new NoContentResult();
    }




}
