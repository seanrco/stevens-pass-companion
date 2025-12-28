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
        return await _wsdotRepository.GetMountainPassConditionAsync(id);
    }

    public async Task<List<WSDOTCamera>> GetCamerasAsync(
        string stateRoute,
        string startingMilepost,
        string endingMilepost)
    {
        return await _wsdotRepository.GetCamerasAsync(stateRoute, startingMilepost, endingMilepost);
    }

}
