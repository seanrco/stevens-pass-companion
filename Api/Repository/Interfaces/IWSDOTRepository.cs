using Microsoft.AspNetCore.Mvc;

namespace Api.Repository.Interfaces;

public interface IWSDOTRepository
{
    Task<IActionResult> GetMountainPassConditionAsync(string id);
    Task<IActionResult> GetCamerasAsync(string StateRoute, string StartingMilepost, string EndingMilepost);
}
