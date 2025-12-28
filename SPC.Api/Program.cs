using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPC.Application.Repositories.Interfaces;
using SPC.Application.Services;
using SPC.Application.Services.Interfaces;
using SPC.Infrascructure.NOAA.Repositories;
using SPC.Infrascructure.WSDOT.Repositories;


var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddSingleton<INOAAService, NOAAService>();
builder.Services.AddSingleton<IWSDOTService, WSDOTService>();
builder.Services.AddSingleton<INOAARepository, NOAARepository>();
builder.Services.AddSingleton<IWSDOTRepository, WSDOTRepository>();

builder.Build().Run();
