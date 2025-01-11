using System.Text.Json.Serialization;

namespace SPC.Core.Models.WSDOT.Report;

public class WSDOTReport
{
    [JsonPropertyName("DateUpdated")]
    public string DateUpdated { get; set; } = string.Empty;

    [JsonPropertyName("ElevationInFeet")]
    public int? ElevationInFeet { get; set; } = null;

    [JsonPropertyName("Latitude")]
    public float? Latitude { get; set; } = null;

    [JsonPropertyName("Longitude")]
    public float? Longitude { get; set; } = null;

    [JsonPropertyName("MountainPassId")]
    public int? MountainPassId { get; set; } = null;

    [JsonPropertyName("MountainPassName")]
    public string MountainPassName { get; set; } = string.Empty;

    [JsonPropertyName("RestrictionOne")]
    public WSDOTReportRestrictionOne? RestrictionOne { get; set; } = null;

    [JsonPropertyName("RestrictionTwo")]
    public WSDOTReportRestrictionTwo? RestrictionTwo { get; set; } = null;

    [JsonPropertyName("RoadCondition")]
    public string RoadCondition { get; set; } = string.Empty;

    [JsonPropertyName("TemperatureInFahrenheit")]
    public int? TemperatureInFahrenheit { get; set; } = null;

    [JsonPropertyName("TravelAdvisoryActive")]
    public bool TravelAdvisoryActive { get; set; }

    [JsonPropertyName("WeatherCondition")]
    public string WeatherCondition { get; set; } = string.Empty;
}

public class WSDOTReportRestrictionOne
{
    [JsonPropertyName("RestrictionText")]
    public string RestrictionText { get; set; } = string.Empty;

    [JsonPropertyName("TravelDirection")]
    public string TravelDirection { get; set; } = string.Empty;
}

public class WSDOTReportRestrictionTwo
{
    [JsonPropertyName("RestrictionText")]
    public string RestrictionText { get; set; } = string.Empty;

    [JsonPropertyName("TravelDirection")]
    public string TravelDirection { get; set; } = string.Empty;
}
