using Microsoft.AspNetCore.Mvc;

namespace Api.Repository.Interfaces;

public interface INOAARepository
{
    Task<IActionResult> GetReport();
}
