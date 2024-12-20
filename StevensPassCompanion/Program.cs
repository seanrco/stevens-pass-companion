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
            

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost",
                                                          "https://localhost:7109/");
                                      builder.AllowAnyMethod();

                                      builder.AllowAnyHeader();

                                      builder.AllowCredentials();
                                  });
            });



            await builder.Build().RunAsync();
        }
    }
}
