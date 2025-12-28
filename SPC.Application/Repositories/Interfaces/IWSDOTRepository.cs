using SPC.Domain.Models.WSDOT.Cameras;
using SPC.Domain.Models.WSDOT.Report;

namespace SPC.Application.Repositories.Interfaces;

public interface IWSDOTRepository
{
    Task<WSDOTReport> GetMountainPassConditionAsync(string id);
    Task<List<WSDOTCamera>> GetCamerasAsync(string stateRoute, string startingMilepost, string endingMilepost);
}
