using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SPC.Application.Services.Interfaces;

using System.Net;

namespace SPC.Api;

/// <summary>
/// NOAA API Endpoints
/// </summary>
public class NOAA
{

    private readonly ILogger<NOAA> _logger;
    private readonly INOAAService _noaaService;

    public NOAA(
        ILogger<NOAA> logger,
        INOAAService noaaService)
    {
        _logger = logger;
        _noaaService = noaaService;
    }


    [Function("NOAAGetActiveAlerts")]
    public async Task<HttpResponseData> GetActiveAlertsAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", 
        Route = "NOAA/GetActiveAlerts")] HttpRequestData req)
    {
        try
        {
            var result = await _noaaService.GetActiveAlerts();

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
            _logger.LogError(ex, "Error retrieving NOAA active alerts");

            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new { error = "An error occurred while processing your request" });
            return errorResponse;
        }
    }

    [Function("NOAAGetForecast")]
    public async Task<HttpResponseData> GetReportAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "NOAA/GetForecast")] HttpRequestData req)
    {
        try
        {
            var result = await _noaaService.GetForecast();

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
            _logger.LogError(ex, "Error retrieving NOAA forecast");

            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new { error = "An error occurred while processing your request" });
            return errorResponse;
        }
    }

    //[Function("NOAAGetActiveAlerts")]
    //public async Task<IActionResult> GetActiveAlertsAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
    //    Route = "NOAA/GetActiveAlerts")] HttpRequest req)
    //{
    //    try
    //    {
    //        return await _noaaRepo.GetActiveAlerts();
    //    }
    //    catch (Exception ex) 
    //    {
    //        _logger.LogError(ex?.Message + ex?.StackTrace);
    //    }

    //    return new NoContentResult();
    //}

    //[Function("NOAAGetForecast")]
    //public async Task<IActionResult> GetReportAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
    //    Route = "NOAA/GetForecast")] HttpRequest req)
    //{
    //    try
    //    {
    //        return await _noaaRepo.GetForecast();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex?.Message + ex?.StackTrace);
    //    }

    //    return new NoContentResult();
    //}

}
