using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Api
{
    public class WSDOT
    {

        private readonly ILogger<WSDOT> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        public WSDOT(ILogger<WSDOT> logger, 
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [Function("WSDOTGetMountainPassCondition")]
        public async Task<IActionResult> GetMountainPassConditionAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
            Route = "WSDOT/GetMountainPassCondition/{id}")] HttpRequestData req, string id,
            FunctionContext executionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string apiUrl = $"https://wsdot.wa.gov/Traffic/api/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionAsJon?AccessCode=0359523e-015e-4244-9e73-cd932eb44542&PassConditionID={id}";

            try
            {

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
                Debug.WriteLine("WSDOTService.GetReportAsync - Error - " + ex.Message + ex.StackTrace);
            }

            return new OkObjectResult(apiUrl);
        }

        [Function("WSDOTGetCameras")]
        public async Task<IActionResult> GetCamerasAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
            Route = "WSDOT/GetCameras/{StateRoute}/{StartingMilepost}/{EndingMilepost}")] HttpRequestData req, 
            string StateRoute, string StartingMilepost, string EndingMilepost,
            FunctionContext executionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string apiUrl = $"https://wsdot.wa.gov/Traffic/api/HighwayCameras/HighwayCamerasREST.svc/SearchCamerasAsJson?AccessCode=0359523e-015e-4244-9e73-cd932eb44542&StateRoute={StateRoute}&StartingMilepost={StartingMilepost}&EndingMilepost={EndingMilepost}";

            try
            {
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
                Debug.WriteLine("WSDOTService.GetReportAsync - Error - " + ex.Message + ex.StackTrace);
            }

            return new OkObjectResult(apiUrl);
        }


    }
}
