using SPC.Domain.Models.WSDOT.Cameras;
using SPC.Domain.Models.WSDOT.Report;

namespace SPC.Application.Services.Interfaces;

public interface IWSDOTService
{
    Task<List<WSDOTCamera>> GetCamerasAsync(string stateRoute, string startingMilepost, string endingMilepost);
    Task<WSDOTReport> GetMountainPassConditionAsync(string id);
}