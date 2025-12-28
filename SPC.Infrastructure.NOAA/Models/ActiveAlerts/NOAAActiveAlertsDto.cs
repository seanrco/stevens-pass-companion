using System.Text.Json.Serialization;

namespace SPC.Infrastructure.NOAA.Models.ActiveAlerts;

public sealed record NOAAActiveAlertsDto
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("features")]
    public FeatureDto[]? Features { get; init; } = null;

    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("updated")]
    public DateTime? Updated { get; init; } = null;

    [JsonPropertyName("pagination")]
    public PaginationDto? Pagination { get; init; } = null;
}

public sealed record PaginationDto
{
    [JsonPropertyName("next")]
    public string Next { get; init; } = string.Empty;
}

public sealed record FeatureDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("properties")]
    public PropertiesDto? Properties { get; init; } = null;
}

public sealed record PropertiesDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("areaDesc")]
    public string AreaDesc { get; init; } = string.Empty;

    [JsonPropertyName("geocode")]
    public GeocodeDto? Geocode { get; init; } = null;

    [JsonPropertyName("affectedZones")]
    public string[]? AffectedZones { get; init; } = null;

    [JsonPropertyName("references")]
    public ReferenceDto[]? References { get; init; } = null;

    [JsonPropertyName("sent")]
    public DateTime? Sent { get; init; } = null;

    [JsonPropertyName("effective")]
    public DateTime? Effective { get; init; } = null;

    [JsonPropertyName(" onset")]
    public DateTime? Onset { get; init; } = null;

    [JsonPropertyName("expires")]
    public DateTime? Expires { get; init; } = null;

    [JsonPropertyName("ends")]
    public DateTime? Ends { get; init; } = null;

    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("messageType")]
    public string MessageType { get; init; } = string.Empty;

    [JsonPropertyName("category")]
    public string Category { get; init; } = string.Empty;

    [JsonPropertyName("severity")]
    public string Severity { get; init; } = string.Empty;

    [JsonPropertyName("certainty")]
    public string Certainty { get; init; } = string.Empty;

    [JsonPropertyName("urgency")]
    public string Urgency { get; init; } = string.Empty;

    [JsonPropertyName("event")]
    public string Event { get; init; } = string.Empty;

    [JsonPropertyName("sender")]
    public string Sender { get; init; } = string.Empty;

    [JsonPropertyName("senderName")]
    public string SenderName { get; init; } = string.Empty;

    [JsonPropertyName("headline")]
    public string Headline { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("instruction")]
    public string Instruction { get; init; } = string.Empty;

    [JsonPropertyName("response")]
    public string Response { get; init; } = string.Empty;

    [JsonPropertyName("parameters")]
    public ParametersDto? Parameters { get; init; } = null;
}

public sealed record GeocodeDto
{
    [JsonPropertyName("UGC")]
    public string[]? UGC { get; init; } = null;

    [JsonPropertyName("SAME")]
    public string[]? SAME { get; init; } = null;
}

public sealed record ParametersDto
{
    [JsonPropertyName("additionalProp1")]
    public object[]? AdditionalProp1 { get; init; } = null;

    [JsonPropertyName("additionalProp2")]
    public object[]? AdditionalProp2 { get; init; } = null;

    [JsonPropertyName("additionalProp3")]
    public object[]? AdditionalProp3 { get; init; } = null;
}

public sealed record ReferenceDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("identifier")]
    public string Identifier { get; init; } = string.Empty;

    [JsonPropertyName("sender")]
    public string Sender { get; init; } = string.Empty;

    [JsonPropertyName("sent")]
    public DateTime? Sent { get; init; } = null;
}
