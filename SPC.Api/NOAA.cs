using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SPC.Infrascructure.Repositories.Interfaces;

namespace SPC.Api;

/// <summary>
/// NOAA API Endpoints
/// </summary>
public class NOAA
{

    private readonly ILogger<NOAA> _logger;
    private readonly INOAARepository _noaaRepo;

    public NOAA(ILogger<NOAA> logger,
        INOAARepository noaaRepo)
    {
        _logger = logger;
        _noaaRepo = noaaRepo;
    }

    [Function("NOAAGetActiveAlerts")]
    public async Task<IActionResult> GetActiveAlertsAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "NOAA/GetActiveAlerts")] HttpRequest req)
    {
        try
        {
            return await _noaaRepo.GetActiveAlerts();
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex?.Message + ex?.StackTrace);
        }

        return new NoContentResult();
    }

    [Function("NOAAGetForecast")]
    public async Task<IActionResult> GetReportAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "NOAA/GetForecast")] HttpRequest req)
    {
        try
        {
            return await _noaaRepo.GetForecast();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex?.Message + ex?.StackTrace);
        }

        return new NoContentResult();
    }


}
