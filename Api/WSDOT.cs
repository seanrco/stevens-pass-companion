using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class WSDOT
    {

        private readonly string _wsdotApiAccessCode = Environment.GetEnvironmentVariable("WSDOT_API_ACCESS_CODE") 
            ?? "0359523e-015e-4244-9e73-cd932eb44542";

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

            return new OkObjectResult("Status: Error.");
        }

        [Function("WSDOTGetCameras")]
        public async Task<IActionResult> GetCamerasAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
            Route = "WSDOT/GetCameras/{StateRoute}/{StartingMilepost}/{EndingMilepost}")] HttpRequestData req, 
            string StateRoute, string StartingMilepost, string EndingMilepost,
            FunctionContext executionContext)
        {
            try
            {
                string apiUrl = $"https://wsdot.wa.gov/Traffic/api/HighwayCameras/HighwayCamerasREST.svc/SearchCamerasAsJson?AccessCode={_wsdotApiAccessCode}&StateRoute={StateRoute}&StartingMilepost={StartingMilepost}&EndingMilepost={EndingMilepost}";

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

            return new OkObjectResult("Status: Error.");
        }


    }
}
