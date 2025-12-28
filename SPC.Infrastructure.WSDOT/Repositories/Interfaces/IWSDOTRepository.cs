using Microsoft.AspNetCore.Mvc;
using SPC.Infrastructure.WSDOT.Models.Cameras;
using SPC.Infrastructure.WSDOT.Models.Report;

namespace SPC.Infrascructure.WSDOT.Repositories.Interfaces;

public interface IWSDOTRepository
{
    Task<WSDOTReport> GetMountainPassConditionAsync(string id);
    Task<List<WSDOTCamera>> GetCamerasAsync(string stateRoute, string startingMilepost, string endingMilepost);
}
