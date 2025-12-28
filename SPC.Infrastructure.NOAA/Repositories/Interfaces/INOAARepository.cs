using SPC.Domain.Models.NOAA.ActiveAlerts;
using SPC.Domain.Models.NOAA.Forecast;

namespace SPC.Infrascructure.NOAA.Repositories.Interfaces;

public interface INOAARepository
{
    Task<NOAAActiveAlerts> GetActiveAlerts();
    Task<NOAAForecast> GetForecast();
}
