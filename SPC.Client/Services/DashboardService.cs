using Microsoft.Extensions.Logging;
using SPC.Core.Models.Dashboard;
using System.Text.Json;

namespace SPC.Core.Services;

public class DashboardService
{
    private readonly ILogger<DashboardService> _logger;
    private readonly HttpClient _httpClient;

    public DashboardService(ILogger<DashboardService> logger, 
        HttpClient httpClient )
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<DashboardSummary?> GetSummaryAsync(string wsdotId, string latitude, string longitude)
    {
        try
        {
            HttpResponseMessage response = await _httpClient
                .GetAsync($"/api/Dashboard/GetSummary/{wsdotId}/{latitude}/{longitude}");

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<DashboardSummary?>(jsonData, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
            _logger.LogError(ex.Message + ex.StackTrace);
        }

        return null;
    }

}
