using Microsoft.AspNetCore.Mvc;

namespace SPC.Api.Repository.Interfaces;

public interface IWSDOTRepository
{
    Task<IActionResult> GetMountainPassConditionAsync(string id);
    Task<IActionResult> GetCamerasAsync(string stateRoute, string startingMilepost, string endingMilepost);
}
