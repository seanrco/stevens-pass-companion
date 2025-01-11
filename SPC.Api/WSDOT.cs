using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using SPC.Infrascructure.Repositories.Interfaces;

namespace SPC.Api;

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
        string stateRoute, string startingMilepost, string endingMilepost,
        FunctionContext executionContext)
    {

        return await _wsdotRepository.GetCamerasAsync(stateRoute, startingMilepost, endingMilepost);

    }


}
