using Microsoft.AspNetCore.Mvc;

namespace SPC.Api.Repository.Interfaces;

public interface INOAARepository
{
    Task<IActionResult> GetReport();
}
