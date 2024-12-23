using System.Net.Http.Json;
using StevensPassCompanion.Models.WSDOT;

namespace StevensPassCompanion.Services;

public class WSDOTService
{

    private readonly ILogger<WSDOTService> _logger;
    private readonly HttpClient _httpClient;

    public WSDOTService(ILogger<WSDOTService> logger,
    HttpClient httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory;
    }

    public async Task<WSDOTReport?> GetReportAsync(string id)
    {
        WSDOTReport report = new WSDOTReport();

        try
        {
            //return await _httpClient.GetFromJsonAsync<NOAAStevensPassForecast>("/api/NOAA/GetReport");

            return await _httpClient.GetFromJsonAsync<WSDOTReport?>($"/api/WSDOT/GetMountainPassCondition/{id}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        //try
        //{
        //    HttpClient? httpClient = _httpClientFactory.CreateClient();

        //    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // TODO - Can we get the json from initial response w/o making a second call below?

        //        string jsonData = await httpClient.GetStringAsync(apiUrl);

        //        if (!string.IsNullOrWhiteSpace(jsonData))
        //        {
        //            return report = JsonConvert.DeserializeObject<WSDOTReport>(jsonData);
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Debug.WriteLine("WSDOTService.GetReportAsync - Error - " + ex.Message + ex.StackTrace);
        //}

        report.IsSuccessStatusCode = false;

        return report;
    }

    /// <summary>
    /// Get Cameras Async
    /// </summary>
    /// <param name="apiUrl">string</param>
    /// <returns>List of type WSDOTCamera obj</returns>
    public async Task<List<WSDOTCamera>> GetCamerasAsync(string apiUrl)
    {
        List<WSDOTCamera> cameras = new List<WSDOTCamera>();

        //try
        //{
        //    HttpClient? httpClient = _httpClientFactory.CreateClient();

        //    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // TODO - Can we get the json from initial response w/o making a second call below?

        //        string jsonData = await httpClient.GetStringAsync(apiUrl);

        //        if (!string.IsNullOrWhiteSpace(jsonData))
        //        {
        //            return cameras = JsonConvert.DeserializeObject<List<WSDOTCamera>>(jsonData);
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Debug.WriteLine("WSDOTService.GetCamerasAsync - Error - " + ex.Message + ex.StackTrace);
        //}

        // TODO - How can we signl was not successful?
        //cameras.IsSuccessStatusCode = false;

        return cameras;
    }


}