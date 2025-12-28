using System.Text.Json.Serialization;

namespace SPC.Infrastructure.WSDOT.Models.Cameras;

public sealed record WSDOTCamera
{
    [JsonPropertyName("CameraID")]
    public int? CameraID { get; init; } = null;

    [JsonPropertyName("CameraLocation")]
    public Cameralocation? CameraLocation { get; init; } = null;

    [JsonPropertyName("CameraOwner")]
    public object? CameraOwner { get; init; } = null;

    [JsonPropertyName("Description")]
    public object? Description { get; init; } = null;

    [JsonPropertyName("DisplayLatitude")]
    public float? DisplayLatitude { get; init; } = null;

    [JsonPropertyName("DisplayLongitude")]
    public float? DisplayLongitude { get; init; } = null;

    [JsonPropertyName("ImageHeight")]
    public int? ImageHeight { get; init; } = null;

    [JsonPropertyName("ImageURL")]
    public string ImageURL { get; init; } = string.Empty;

    [JsonPropertyName("ImageWidth")]
    public int? ImageWidth { get; init; } = null;

    [JsonPropertyName("IsActive")]
    public bool IsActive { get; init; }

    [JsonPropertyName("OwnerURL")]
    public object? OwnerURL { get; init; } = null;

    [JsonPropertyName("Region")]
    public string Region { get; init; } = string.Empty;

    [JsonPropertyName("SortOrder")]
    public int? SortOrder { get; init; } = null;

    [JsonPropertyName("Title")]
    public string Title { get; init; } = string.Empty;
}

public sealed record Cameralocation
{
    [JsonPropertyName("Description")]
    public object? Description { get; init; } = null;

    [JsonPropertyName("Direction")]
    public string Direction { get; init; } = string.Empty;

    [JsonPropertyName("Latitude")]
    public float? Latitude { get; init; } = null;

    [JsonPropertyName("Longitude")]
    public float? Longitude { get; init; } = null;

    [JsonPropertyName("MilePost")]
    public int? MilePost { get; init; } = null;

    [JsonPropertyName("RoadName")]
    public string RoadName { get; init; } = string.Empty;
}
