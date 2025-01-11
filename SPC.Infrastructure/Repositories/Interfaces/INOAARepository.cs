﻿using Microsoft.AspNetCore.Mvc;

namespace SPC.Infrascructure.Repositories.Interfaces;

public interface INOAARepository
{
    Task<IActionResult> GetActiveAlerts();
    Task<IActionResult> GetForecast();
}
