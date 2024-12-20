using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using StevensPassCompanion.Models.NOAA;

namespace StevensPassCompanion.Services;

public class NOAAService
{
    public readonly string NOAA_SP_API_URL = "https://api.weather.gov/gridpoints/OTX/25,115/forecast";

    private readonly IHttpClientFactory _httpClientFactory;

    public NOAAService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<NOAAStevensPassForecast> GetForecastAsync()
    {
        // TODO CAll https://api.weather.gov/ to check for ok status before calling forecast endpoint

        NOAAStevensPassForecast forecast = new NOAAStevensPassForecast();

        try
        {
            HttpClient? httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "StevensPassCompanionApp");

            HttpResponseMessage? response = await httpClient.GetAsync(NOAA_SP_API_URL);

            if (response.IsSuccessStatusCode)
            {

                // TODO - Can we get the json from initial response w/o making a second call below?

                string jsonData = await httpClient.GetStringAsync(NOAA_SP_API_URL);

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return forecast = JsonConvert.DeserializeObject<NOAAStevensPassForecast>(jsonData);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("NOAAService.GetForecastAsync - Error - " + ex.Message + ex.StackTrace);
        }

        forecast.IsSuccessStatusCode = false;

        return forecast;
    }

}