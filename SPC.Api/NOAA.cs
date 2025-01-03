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

    [Function("NOAA")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "NOAA/GetReport")] HttpRequest req)
    {

        return await _noaaRepo.GetReport();

    }


}
