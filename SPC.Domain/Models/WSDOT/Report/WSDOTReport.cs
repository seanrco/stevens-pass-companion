namespace SPC.Domain.Models.WSDOT.Report;

public class WSDOTReport
{
    public string DateUpdated { get; set; } = string.Empty;
    public int? ElevationInFeet { get; set; } = null;
    public float? Latitude { get; set; } = null;
    public float? Longitude { get; set; } = null;
    public int? MountainPassId { get; set; } = null;
    public string MountainPassName { get; set; } = string.Empty;
    public WSDOTReportRestrictionOne? RestrictionOne { get; set; } = null;
    public WSDOTReportRestrictionTwo? RestrictionTwo { get; set; } = null;
    public string RoadCondition { get; set; } = string.Empty;
    public int? TemperatureInFahrenheit { get; set; } = null;
    public bool TravelAdvisoryActive { get; set; }
    public string WeatherCondition { get; set; } = string.Empty;
}

public class WSDOTReportRestrictionOne
{
    public string RestrictionText { get; set; } = string.Empty;
    public string TravelDirection { get; set; } = string.Empty;
}

public class WSDOTReportRestrictionTwo
{
    public string RestrictionText { get; set; } = string.Empty;
    public string TravelDirection { get; set; } = string.Empty;
}
