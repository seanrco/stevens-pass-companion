using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using SPC.Api.Repository.Interfaces;

namespace SPC.Api;

public class NOAA
{

    private readonly INOAARepository _noaaRepo;

    public NOAA(INOAARepository noaaRepo)
    {
        _noaaRepo = noaaRepo;
    }

    [Function("NOAAGetActiveAlerts")]
    public async Task<IActionResult> GetActiveAlertsAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "NOAA/GetActiveAlerts")] HttpRequest req)
    {

        return await _noaaRepo.GetActiveAlerts();

    }

    [Function("NOAAGetReport")]
    public async Task<IActionResult> GetReportAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "NOAA/GetReport")] HttpRequest req)
    {

        return await _noaaRepo.GetReport();

    }


}
