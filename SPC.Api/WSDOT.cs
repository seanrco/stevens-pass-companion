using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SPC.Infrascructure.WSDOT.Repositories.Interfaces;
using System.Net;

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
    public async Task<HttpResponseData> GetMountainPassConditionAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", 
        Route = "WSDOT/GetMountainPassCondition/{id}")] HttpRequestData req,
        string id,
        FunctionContext executionContext)
    {
        try
        {
            var result = await _wsdotRepository.GetMountainPassConditionAsync(id);

            if (result == null)
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NoContent);
                return notFoundResponse;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(result);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving mountain pass condition for id: {Id}", id);

            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new { error = "An error occurred while processing your request" });
            return errorResponse;
        }
    }

    [Function("WSDOTGetCameras")]
    public async Task<HttpResponseData> GetCamerasAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", 
        Route = "WSDOT/GetCameras/{StateRoute}/{StartingMilepost}/{EndingMilepost}")] HttpRequestData req,
        string stateRoute,
        string startingMilepost,
        string endingMilepost,
        FunctionContext executionContext)
    {
        try
        {
            var result = await _wsdotRepository
                .GetCamerasAsync(stateRoute, startingMilepost, endingMilepost);

            if (result == null || !result.Any())
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NoContent);
                return notFoundResponse;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(result);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving cameras for route: {StateRoute}, mileposts: {Start}-{End}",
                stateRoute, startingMilepost, endingMilepost);

            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new { error = "An error occurred while processing your request" });
            return errorResponse;
        }
    }

    //[Function("WSDOTGetMountainPassCondition")]
    //public async Task<WSDOTReport> GetMountainPassConditionAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
    //    Route = "WSDOT/GetMountainPassCondition/{id}")] HttpRequestData req, string id,
    //    FunctionContext executionContext)
    //{
    //    try
    //    {
    //        return await _wsdotRepository.GetMountainPassConditionAsync(id);
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError((ex?.Message ?? string.Empty) + (ex?.StackTrace ?? string.Empty));
    //    }

    //    return null;
    //}

    //[Function("WSDOTGetCameras")]
    //public async Task<IActionResult> GetCamerasAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
    //    Route = "WSDOT/GetCameras/{StateRoute}/{StartingMilepost}/{EndingMilepost}")] HttpRequestData req,
    //    string stateRoute, string startingMilepost, string endingMilepost,
    //    FunctionContext executionContext)
    //{
    //    try
    //    {
    //        return await _wsdotRepository
    //            .GetCamerasAsync(stateRoute, startingMilepost, endingMilepost);
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex?.Message + ex?.StackTrace);
    //    }

    //    return new NoContentResult();
    //}


}
