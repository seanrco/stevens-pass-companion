using System.Text.Json.Serialization;

namespace SPC.Infrastructure.WSDOT.Models.Report;

public record WSDOTReport
{
    [JsonPropertyName("DateUpdated")]
    public string DateUpdated { get; init; } = string.Empty;

    [JsonPropertyName("ElevationInFeet")]
    public int? ElevationInFeet { get; init; } = null;

    [JsonPropertyName("Latitude")]
    public float? Latitude { get; init; } = null;

    [JsonPropertyName("Longitude")]
    public float? Longitude { get; init; } = null;

    [JsonPropertyName("MountainPassId")]
    public int? MountainPassId { get; init; } = null;

    [JsonPropertyName("MountainPassName")]
    public string MountainPassName { get; init; } = string.Empty;

    [JsonPropertyName("RestrictionOne")]
    public WSDOTReportRestrictionOne? RestrictionOne { get; init; } = null;

    [JsonPropertyName("RestrictionTwo")]
    public WSDOTReportRestrictionTwo? RestrictionTwo { get; init; } = null;

    [JsonPropertyName("RoadCondition")]
    public string RoadCondition { get; init; } = string.Empty;

    [JsonPropertyName("TemperatureInFahrenheit")]
    public int? TemperatureInFahrenheit { get; init; } = null;

    [JsonPropertyName("TravelAdvisoryActive")]
    public bool TravelAdvisoryActive { get; init; }

    [JsonPropertyName("WeatherCondition")]
    public string WeatherCondition { get; init; } = string.Empty;
}

public record WSDOTReportRestrictionOne
{
    [JsonPropertyName("RestrictionText")]
    public string RestrictionText { get; init; } = string.Empty;

    [JsonPropertyName("TravelDirection")]
    public string TravelDirection { get; init; } = string.Empty;
}

public record WSDOTReportRestrictionTwo
{
    [JsonPropertyName("RestrictionText")]
    public string RestrictionText { get; init; } = string.Empty;

    [JsonPropertyName("TravelDirection")]
    public string TravelDirection { get; init; } = string.Empty;
}
