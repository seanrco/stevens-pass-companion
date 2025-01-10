using System.Text.Json.Serialization;

namespace SPC.Core.Models.NOAA.ActiveAlerts;

public class NOAAActiveAlerts
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("features")]
    public Feature[]? Features { get; set; } = null;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; } = null;

    [JsonPropertyName("pagination")]
    public Pagination? Pagination { get; set; } = null;
}

public class Pagination
{
    [JsonPropertyName("next")]
    public string Next { get; set; } = string.Empty;
}

public class Feature
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("properties")]
    public Properties? Properties { get; set; } = null;
}

public class Properties
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("areaDesc")]
    public string AreaDesc { get; set; } = string.Empty;

    [JsonPropertyName("geocode")]
    public Geocode? Geocode { get; set; } = null;

    [JsonPropertyName("affectedZones")]
    public string[]? AffectedZones { get; set; } = null;

    [JsonPropertyName("references")]
    public Reference[]? References { get; set; } = null;

    [JsonPropertyName("sent")]
    public DateTime? Sent { get; set; } = null;

    [JsonPropertyName("effective")]
    public DateTime? Effective { get; set; } = null;

    [JsonPropertyName(" onset")]
    public DateTime? Onset { get; set; } = null;

    [JsonPropertyName("expires")]
    public DateTime? Expires { get; set; } = null;

    [JsonPropertyName("ends")]
    public DateTime? Ends { get; set; } = null;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("messageType")]
    public string MessageType { get; set; } = string.Empty;

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("severity")]
    public string Severity { get; set; } = string.Empty;

    [JsonPropertyName("certainty")]
    public string Certainty { get; set; } = string.Empty;

    [JsonPropertyName("urgency")]
    public string Urgency { get; set; } = string.Empty;

    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;

    [JsonPropertyName("sender")]
    public string Sender { get; set; } = string.Empty;

    [JsonPropertyName("senderName")]
    public string SenderName { get; set; } = string.Empty;

    [JsonPropertyName("headline")]
    public string Headline { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("instruction")]
    public string Instruction { get; set; } = string.Empty;

    [JsonPropertyName("response")]
    public string Response { get; set; } = string.Empty;

    [JsonPropertyName("parameters")]
    public Parameters? Parameters { get; set; } = null;
}

public class Geocode
{
    [JsonPropertyName("UGC")]
    public string[]? UGC { get; set; } = null;

    [JsonPropertyName("SAME")]
    public string[]? SAME { get; set; } = null;
}

public class Parameters
{
    [JsonPropertyName("additionalProp1")]
    public object[]? AdditionalProp1 { get; set; } = null;

    [JsonPropertyName("additionalProp2")]
    public object[]? AdditionalProp2 { get; set; } = null;

    [JsonPropertyName("additionalProp3")]
    public object[]? AdditionalProp3 { get; set; } = null;
}

public class Reference
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = string.Empty;

    [JsonPropertyName("sender")]
    public string Sender { get; set; } = string.Empty;

    [JsonPropertyName("sent")]
    public DateTime? Sent { get; set; } = null;
}
