using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPC.Infrascructure.Repositories.Interfaces;
using SPC.Infrascructure.Utilities;

namespace SPC.Infrascructure.Repositories;

public class WSDOTRepository : IWSDOTRepository
{

    private string _wsdotApiAccessCode = AzureUtilities.GetEnvironmentVariable("WSDOT_API_ACCESS_CODE");

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
