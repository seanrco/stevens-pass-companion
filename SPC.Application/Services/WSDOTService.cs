using Microsoft.Extensions.Logging;
using SPC.Application.Repositories.Interfaces;
using SPC.Application.Services.Interfaces;
using SPC.Domain.Models.WSDOT.Cameras;
using SPC.Domain.Models.WSDOT.Report;

namespace SPC.Application.Services;

public class WSDOTService : IWSDOTService
{
    private readonly ILogger<WSDOTService> _logger;
    private readonly IWSDOTRepository _wsdotRepository;

    public WSDOTService(
        ILogger<WSDOTService> logger,
        IWSDOTRepository wsdotRepository)
    {
        _logger = logger;
        _wsdotRepository = wsdotRepository;
    }

    public async Task<WSDOTReport> GetMountainPassConditionAsync(string id)
    {
        if(string.IsNullOrWhiteSpace(id))
        {
            _logger.LogWarning("GetMountainPassConditionAsync called with null or empty id.");
            return null;
        }

        return await _wsdotRepository.GetMountainPassConditionAsync(id);
    }

    public async Task<List<WSDOTCamera>> GetCamerasAsync(
        string stateRoute,
        string startingMilepost,
        string endingMilepost)
    {
        if(string.IsNullOrWhiteSpace(stateRoute) || 
            string.IsNullOrWhiteSpace(startingMilepost) ||
            string.IsNullOrWhiteSpace(endingMilepost))
        {
            _logger.LogWarning("GetCamerasAsync called with null or empty parameters.");
            return null;
        }

        return await _wsdotRepository.GetCamerasAsync(stateRoute, startingMilepost, endingMilepost);
    }

}
