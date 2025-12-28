using SPC.Domain.Models.NOAA.ActiveAlerts;
using SPC.Domain.Models.NOAA.Forecast;

namespace SPC.Application.Services.Interfaces;

public interface INOAAService
{
    Task<NOAAActiveAlerts> GetActiveAlerts();
    Task<NOAAForecast> GetForecast();
}