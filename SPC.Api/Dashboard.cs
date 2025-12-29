using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SPC.Application.Services.Interfaces;
using System.Net;

namespace SPC.Api;

public class Dashboard
{
    private readonly ILogger<Dashboard> _logger;
    private readonly IDashboardService _dashboardService;

    public Dashboard(ILogger<Dashboard> logger,
        IDashboardService dashboardService)
    {
        _logger = logger;
        _dashboardService = dashboardService;
    }

    [Function("DashboardSummary")]
    public async Task<HttpResponseData> GetSummaryAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Dashboard/GetSummary/{id}")] HttpRequestData req,
        string id,
        FunctionContext executionContext)
    {
        try
        {
            var result = await _dashboardService.GetDashboardSummaryAsync(id);

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
            _logger.LogError(ex, "Error retrieving dashboard summary.");

            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new { error = "Error retrieving dashboard summary." });
            return errorResponse;
        }
    }

}