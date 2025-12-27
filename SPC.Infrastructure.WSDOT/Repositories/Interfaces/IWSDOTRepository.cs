using Microsoft.AspNetCore.Mvc;

namespace SPC.Infrascructure.WSDOT.Repositories.Interfaces;

public interface IWSDOTRepository
{
    Task<IActionResult> GetMountainPassConditionAsync(string id);
    Task<IActionResult> GetCamerasAsync(string stateRoute, string startingMilepost, string endingMilepost);
}
