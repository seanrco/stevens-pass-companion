using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPC.Infrascructure.Repositories;
using SPC.Infrascructure.Repositories.Interfaces;


var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddSingleton<INOAARepository, NOAARepository>();
builder.Services.AddSingleton<IWSDOTRepository, WSDOTRepository>();

builder.Build().Run();
