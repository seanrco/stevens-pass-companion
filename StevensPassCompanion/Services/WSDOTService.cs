using System.Diagnostics;
using Newtonsoft.Json;
using StevensPassCompanion.Models.WSDOT;

namespace StevensPassCompanion.Services;

public class WSDOTService
{

    HttpClient httpClient;
    public WSDOTService()
    {
        this.httpClient = new HttpClient();
    }

    /// <summary>
    /// Get Report Async
    /// </summary>
    /// <param name="apiUrl">string</param>
    /// <returns>WSDOTReport object</returns>
    public async Task<WSDOTReport> GetReportAsync(string apiUrl)
    {
        WSDOTReport report = new WSDOTReport();

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // TODO - Can we get the json from initial response w/o making a second call below?

                string jsonData = await httpClient.GetStringAsync(apiUrl);

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return report = JsonConvert.DeserializeObject<WSDOTReport>(jsonData);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("WSDOTService.GetReportAsync - Error - " + ex.Message + ex.StackTrace);
        }

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

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // TODO - Can we get the json from initial response w/o making a second call below?

                string jsonData = await httpClient.GetStringAsync(apiUrl);

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return cameras = JsonConvert.DeserializeObject<List<WSDOTCamera>>(jsonData);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("WSDOTService.GetCamerasAsync - Error - " + ex.Message + ex.StackTrace);
        }

        // TODO - How can we signl was not successful?
        //cameras.IsSuccessStatusCode = false;

        return cameras;
    }


}