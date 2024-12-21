using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StevensPassCompanion.Services;

namespace StevensPassCompanion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddMudServices();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<WSDOTService>();
            builder.Services.AddSingleton<NOAAService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseAddress"] ?? builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
