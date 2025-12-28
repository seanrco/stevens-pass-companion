using System.Text.Json.Serialization;

namespace SPC.Infrastructure.NOAA.Models.Forecast;

public sealed record NOAAForecastDto
{
    [JsonPropertyName("contex")]
    public object[]? Context { get; init; } = null;

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("geometry")]
    public GeometryDto? Geometry { get; init; } = null;

    [JsonPropertyName("properties")]
    public PropertiesDto? Properties { get; init; } = null;
}

public sealed record GeometryDto
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("coordinates")]
    public float[][][]? Coordinates { get; init; } = null;
}

public sealed record PropertiesDto
{
    [JsonPropertyName("update")]
    public DateTime? Updated { get; init; } = null;

    [JsonPropertyName("units")]
    public string Units { get; init; } = string.Empty;

    [JsonPropertyName("forecastGenerator")]
    public string ForecastGenerator { get; init; } = string.Empty;

    [JsonPropertyName("generatedAt")]
    public DateTime? GeneratedAt { get; init; } = null;

    [JsonPropertyName("updateTime")]
    public DateTime? UpdateTime { get; init; } = null;

    [JsonPropertyName("validTimes")]
    public string ValidTimes { get; init; } = string.Empty;

    [JsonPropertyName("elevation")]
    public ElevationDto? Elevation { get; init; } = null;

    [JsonPropertyName("periods")]
    public PeriodDto[]? Periods { get; init; } = null;
}

public sealed record ElevationDto
{
    [JsonPropertyName("unitCode")]
    public string UnitCode { get; init; } = string.Empty;

    [JsonPropertyName("value")]
    public float Value { get; init; }
}

public sealed record PeriodDto
{
    [JsonPropertyName("number")]
    public int Number { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; init; } = null;

    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; init; } = null;

    [JsonPropertyName("isDaytime")]
    public bool IsDaytime { get; init; }

    [JsonPropertyName("temperature")]
    public int Temperature { get; init; }

    [JsonPropertyName("temperatureUnit")]
    public string TemperatureUnit { get; init; } = string.Empty;

    [JsonPropertyName("temperatureTrend")]
    public string TemperatureTrend { get; init; } = string.Empty;

    [JsonPropertyName("windSpeed")]
    public string WindSpeed { get; init; } = string.Empty;

    [JsonPropertyName("windDirection")]
    public string WindDirection { get; init; } = string.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; init; } = string.Empty;

    [JsonPropertyName("shortForecast")]
    public string ShortForecast { get; init; } = string.Empty;

    [JsonPropertyName("detailedForecast")]
    public string DetailedForecast { get; init; } = string.Empty;
}