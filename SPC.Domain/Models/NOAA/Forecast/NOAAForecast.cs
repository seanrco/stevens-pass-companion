using System.Text.Json.Serialization;

namespace SPC.Domain.Models.NOAA.Forecast;

public class NOAAForecast
{
    [JsonPropertyName("contex")]
    public object[]? Context { get; set; } = null;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("geometry")]
    public Geometry? Geometry { get; set; } = null;

    [JsonPropertyName("properties")]
    public Properties? Properties { get; set; } = null;
}

public class Geometry
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("coordinates")]
    public float[][][]? Coordinates { get; set; } = null;
}

public class Properties
{
    [JsonPropertyName("update")]
    public DateTime? Updated { get; set; } = null;

    [JsonPropertyName("units")]
    public string Units { get; set; } = string.Empty;

    [JsonPropertyName("forecastGenerator")]
    public string ForecastGenerator { get; set; } = string.Empty;

    [JsonPropertyName("generatedAt")]
    public DateTime? GeneratedAt { get; set; } = null;

    [JsonPropertyName("updateTime")]
    public DateTime? UpdateTime { get; set; } = null;

    [JsonPropertyName("validTimes")]
    public string ValidTimes { get; set; } = string.Empty;

    [JsonPropertyName("elevation")]
    public Elevation? Elevation { get; set; } = null;

    [JsonPropertyName("periods")]
    public Period[]? Periods { get; set; } = null;
}

public class Elevation
{
    [JsonPropertyName("unitCode")]
    public string UnitCode { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public float Value { get; set; }
}

public class Period
{
    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; } = null;

    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; } = null;

    [JsonPropertyName("isDaytime")]
    public bool IsDaytime { get; set; }

    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }

    [JsonPropertyName("temperatureUnit")]
    public string TemperatureUnit { get; set; } = string.Empty;

    [JsonPropertyName("temperatureTrend")]
    public string TemperatureTrend { get; set; } = string.Empty;

    [JsonPropertyName("windSpeed")]
    public string WindSpeed { get; set; } = string.Empty;

    [JsonPropertyName("windDirection")]
    public string WindDirection { get; set; } = string.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; set; } = string.Empty;

    [JsonPropertyName("shortForecast")]
    public string ShortForecast { get; set; } = string.Empty;

    [JsonPropertyName("detailedForecast")]
    public string DetailedForecast { get; set; } = string.Empty;
}