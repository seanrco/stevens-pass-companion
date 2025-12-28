namespace SPC.Domain.Models.NOAA.ActiveAlerts;

public class NOAAActiveAlerts
{
    public string Type { get; set; } = string.Empty;
    public Feature[]? Features { get; set; } = null;
    public string Title { get; set; } = string.Empty;
    public DateTime? Updated { get; set; } = null;
}

public class Feature
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Properties? Properties { get; set; } = null;
}

public class Properties
{
    public string Id { get; set; } = string.Empty;
    public string AreaDesc { get; set; } = string.Empty;
    public string[]? AffectedZones { get; set; } = null;
    public DateTime? Sent { get; set; } = null;
    public DateTime? Effective { get; set; } = null;
    public DateTime? Onset { get; set; } = null;
    public DateTime? Expires { get; set; } = null;
    public DateTime? Ends { get; set; } = null;
    public string Status { get; set; } = string.Empty;
    public string MessageType { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Certainty { get; set; } = string.Empty;
    public string Urgency { get; set; } = string.Empty;
    public string Event { get; set; } = string.Empty;
    public string Sender { get; set; } = string.Empty;
    public string SenderName { get; set; } = string.Empty;
    public string Headline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Instruction { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;
}
