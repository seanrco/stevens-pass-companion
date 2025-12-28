using Microsoft.Extensions.Logging;
using SPC.Application.Repositories.Interfaces;
using SPC.Application.Services.Interfaces;
using SPC.Domain.Models.NOAA.ActiveAlerts;
using SPC.Domain.Models.NOAA.Forecast;

namespace SPC.Application.Services;

public class NOAAService : INOAAService
{
    private readonly ILogger<NOAAService> _logger;
    private readonly INOAARepository _noaaRepository;

    public NOAAService(
        ILogger<NOAAService> logger,
        INOAARepository noaaRepository)
    {
        _logger = logger;
        _noaaRepository = noaaRepository;
    }

    public async Task<NOAAActiveAlerts> GetActiveAlerts()
    {
        return await _noaaRepository.GetActiveAlerts();
    }

    public async Task<NOAAForecast> GetForecast()
    {
        return await _noaaRepository.GetForecast();
    }

}
