using Microsoft.Extensions.Logging;
using SPC.Application.Repositories.Interfaces;
using SPC.Application.Services.Interfaces;
using SPC.Domain.Models.Dashboard;

namespace SPC.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly ILogger<DashboardService> _logger;
    private readonly IWSDOTRepository _wsdotRepository;
    private readonly INOAARepository _noaaRepository;

    public DashboardService(ILogger<DashboardService> logger,
        IWSDOTRepository wsdotRepository,
        INOAARepository noaaRepository)
    {
        _logger = logger;
        _wsdotRepository = wsdotRepository;
        _noaaRepository = noaaRepository;
    }

    public async Task<DashboardSummary> GetDashboardSummaryAsync(string wsdotId,
        string latitude,
        string longitude)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(wsdotId) ||
                string.IsNullOrWhiteSpace(latitude) ||
                string.IsNullOrWhiteSpace(longitude))
            {
                return null;
            }

            var wsdotReport = _wsdotRepository.GetMountainPassConditionAsync(wsdotId);
            var noaaForecast = _noaaRepository.GetForecast(latitude, longitude);

            if (wsdotReport == null || noaaForecast == null)
            {
                return null;
            }

            var wsdotSummary = new WSDOTSummary()
            {
                MountainPassName = wsdotReport?.Result?.MountainPassName ?? string.Empty,
                DateUpdated = wsdotReport?.Result?.DateUpdated ?? string.Empty,
                RestrictionOneText = wsdotReport?.Result?.RestrictionOne?.RestrictionText ?? string.Empty,
                RestrictionOneTravelDirection = wsdotReport?.Result.RestrictionOne?.TravelDirection ?? string.Empty,
                RestrictionTwoText = wsdotReport?.Result?.RestrictionTwo?.RestrictionText ?? string.Empty,
                RestrictionTwoTravelDirection = wsdotReport?.Result?.RestrictionTwo?.TravelDirection ?? string.Empty
            };

            var noaaSummary = new NOAASummary()
            {
                DateUpdated = noaaForecast?.Result?.Properties?.Updated ?? null,
                Period = noaaForecast?.Result?.Properties?.Periods?.FirstOrDefault() ?? null
            };

            var dashboardSummary = new DashboardSummary()
            {
                WSDOTSummary = wsdotSummary,
                NOAASummary = noaaSummary
            };

            return dashboardSummary;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ex.StackTrace);
            return null;
        }
    }


}
