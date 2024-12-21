namespace StevensPassCompanion.Models.WSDOT;

public class WSDOTReport
{
    public string DateUpdated { get; set; }
    public int? ElevationInFeet { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public int? MountainPassId { get; set; }
    public string MountainPassName { get; set; }
    public WSDOTReportRestrictionOne RestrictionOne { get; set; }
    public WSDOTReportRestrictionTwo RestrictionTwo { get; set; }
    public string RoadCondition { get; set; }
    public int? TemperatureInFahrenheit { get; set; }
    public bool TravelAdvisoryActive { get; set; }
    public string WeatherCondition { get; set; }
    public bool IsSuccessStatusCode { get; set; } = true;
}

public class WSDOTReportRestrictionOne
{
    public string RestrictionText { get; set; }
    public string TravelDirection { get; set; }
}

public class WSDOTReportRestrictionTwo
{
    public string RestrictionText { get; set; }
    public string TravelDirection { get; set; }
}
