using Api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
namespace Api;

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
