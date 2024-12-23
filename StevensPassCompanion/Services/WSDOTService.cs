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

    public async Task<WSDOTReport?> GetReportAsync(string value)
    {
        try
        {
            string id = string.Empty;

            if (value.Equals("StevensPass", StringComparison.InvariantCultureIgnoreCase))
            {
                id = "10";
            }
            else if (value.Equals("BlewettPass", StringComparison.InvariantCultureIgnoreCase))
            {
                id = "1";
            }
            else if (value.Equals("SnoqualmiePass", StringComparison.InvariantCultureIgnoreCase))
            {
                id = "11";
            }

            return await _httpClient.GetFromJsonAsync<WSDOTReport?>($"/api/WSDOT/GetMountainPassCondition/{id}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return null;
    }

    public async Task<List<WSDOTCamera>?> GetCamerasAsync(string value)
    {
        try
        {
            string stateRoute = string.Empty;
            string startingMilepost = string.Empty;
            string endingMilepost = string.Empty;

            if (value.Equals("StevensPass", StringComparison.InvariantCultureIgnoreCase))
            {
                stateRoute = "US%202&";
                startingMilepost = "61";
                endingMilepost = "85";
            }
            else if (value.Equals("BlewettPass", StringComparison.InvariantCultureIgnoreCase))
            {
                stateRoute = "US%2097&";
                startingMilepost = "164";
                endingMilepost = "164";
            }
            else if (value.Equals("SnoqualmiePass", StringComparison.InvariantCultureIgnoreCase))
            {
                stateRoute = "I-90&";
                startingMilepost = "45";
                endingMilepost = "97";
            }

            return await _httpClient.GetFromJsonAsync<List<WSDOTCamera>?>($"/api/WSDOT/GetCameras/{stateRoute}/{startingMilepost}/{endingMilepost}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return null;

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

        //return cameras;
    }


}