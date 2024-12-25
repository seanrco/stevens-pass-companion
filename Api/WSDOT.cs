using Api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class WSDOT
    {

        public readonly IWSDOTRepository _wsdotRepository;

        public WSDOT(IWSDOTRepository wsdotRepository)
        {
            _wsdotRepository = wsdotRepository;
        }

        [Function("WSDOTGetMountainPassCondition")]
        public async Task<IActionResult> GetMountainPassConditionAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
            Route = "WSDOT/GetMountainPassCondition/{id}")] HttpRequestData req, string id,
            FunctionContext executionContext)
        {

            return await _wsdotRepository.GetMountainPassConditionAsync(id);

        }

        [Function("WSDOTGetCameras")]
        public async Task<IActionResult> GetCamerasAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
            Route = "WSDOT/GetCameras/{StateRoute}/{StartingMilepost}/{EndingMilepost}")] HttpRequestData req, 
            string StateRoute, string StartingMilepost, string EndingMilepost,
            FunctionContext executionContext)
        {

            return await _wsdotRepository.GetCamerasAsync(StateRoute, StartingMilepost, EndingMilepost);

        }


    }
}
