using Newtonsoft.Json;
using StevensPassCompanion.Models.NOAA;
using System.Diagnostics;

namespace StevensPassCompanion.Services;

public class NOAAService
{
    public readonly string NOAA_SP_API_URL = "/api/NOAA/GetReport";

    private readonly IHttpClientFactory _httpClientFactory;

    public NOAAService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<NOAAStevensPassForecast?> GetForecastAsync()
    {
        // TODO CAll https://api.weather.gov/ to check for ok status before calling forecast endpoint

        try
        {
            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

            HttpResponseMessage? response = await httpClient.GetAsync(NOAA_SP_API_URL);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await httpClient.GetStringAsync(NOAA_SP_API_URL);

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return JsonConvert.DeserializeObject<NOAAStevensPassForecast>(jsonData);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("NOAAService.GetForecastAsync - Error - " + ex.Message + ex.StackTrace);
        }

        return null;
    }

}