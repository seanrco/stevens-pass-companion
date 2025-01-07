using SPC.Client.Models.NOAA.Forecast;
using SPC.Client.Models.WSDOT;
using System.Net.Http.Json;
using System.Text.Json;

namespace SPC.Client.Services;

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

            HttpResponseMessage response = await _httpClient.GetAsync($"/api/WSDOT/GetMountainPassCondition/{id}");

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<WSDOTReport?>(jsonData, options);

                //return await _httpClient.GetFromJsonAsync<WSDOTReport?>($"/api/WSDOT/GetMountainPassCondition/{id}", options);
            }
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

            HttpResponseMessage response = await _httpClient.GetAsync($"/api/WSDOT/GetCameras/{stateRoute}/{startingMilepost}/{endingMilepost}");

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<List<WSDOTCamera>?>(jsonData, options);

                //return await _httpClient.GetFromJsonAsync<List<WSDOTCamera>?>($"/api/WSDOT/GetCameras/{stateRoute}/{startingMilepost}/{endingMilepost}", options);
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