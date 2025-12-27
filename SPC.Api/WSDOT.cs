using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SPC.Infrascructure.WSDOT.Repositories.Interfaces;

namespace SPC.Api;

/// <summary>
/// WSDOT API Endpoints
/// </summary>
public class WSDOT
{

    private readonly ILogger<WSDOT> _logger;
    public readonly IWSDOTRepository _wsdotRepository;

    public WSDOT(ILogger<WSDOT> logger, 
        IWSDOTRepository wsdotRepository)
    {
        _logger = logger;
        _wsdotRepository = wsdotRepository;
    }

    [Function("WSDOTGetMountainPassCondition")]
    public async Task<IActionResult> GetMountainPassConditionAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "WSDOT/GetMountainPassCondition/{id}")] HttpRequestData req, string id,
        FunctionContext executionContext)
    {
        try
        {
            return await _wsdotRepository
                .GetMountainPassConditionAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex?.Message + ex?.StackTrace);
        }

        return new NoContentResult();
    }

    [Function("WSDOTGetCameras")]
    public async Task<IActionResult> GetCamerasAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "WSDOT/GetCameras/{StateRoute}/{StartingMilepost}/{EndingMilepost}")] HttpRequestData req,
        string stateRoute, string startingMilepost, string endingMilepost,
        FunctionContext executionContext)
    {
        try
        {
            return await _wsdotRepository
                .GetCamerasAsync(stateRoute, startingMilepost, endingMilepost);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex?.Message + ex?.StackTrace);
        }

        return new NoContentResult();
    }


}
