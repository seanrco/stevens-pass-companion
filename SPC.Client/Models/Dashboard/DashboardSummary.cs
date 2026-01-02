using SPC.Core.Models.NOAA.Forecast;

namespace SPC.Core.Models.Dashboard;

public class DashboardSummary
{
    public WSDOTSummary WSDOTSummary { get; set; } = new WSDOTSummary();
    public NOAASummary NOAASummary { get; set; } = new NOAASummary();
}

public class WSDOTSummary
{
    public string MountainPassName { get; set; } = string.Empty;
    public string DateUpdated { get; set; } = string.Empty;
    public string RestrictionOneText { get; set; } = string.Empty;
    public string RestrictionOneTravelDirection { get; set; } = string.Empty;
    public string RestrictionTwoText { get; set; } = string.Empty;
    public string RestrictionTwoTravelDirection { get; set; } = string.Empty;   
}

public class NOAASummary
{
    public DateTime? DateUpdated { get; set; } = null;
    public Period[]? Periods { get; set; } = null;
}