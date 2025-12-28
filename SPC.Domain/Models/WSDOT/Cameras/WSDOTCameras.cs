using System.Text.Json.Serialization;

namespace SPC.Domain.Models.WSDOT.Cameras;

public class WSDOTCamera
{
    [JsonPropertyName("CameraID")]
    public int? CameraID { get; set; } = null;

    [JsonPropertyName("CameraLocation")]
    public Cameralocation? CameraLocation { get; set; } = null;

    [JsonPropertyName("CameraOwner")]
    public object? CameraOwner { get; set; } = null;

    [JsonPropertyName("Description")]
    public object? Description { get; set; } = null;

    [JsonPropertyName("DisplayLatitude")]
    public float? DisplayLatitude { get; set; } = null;

    [JsonPropertyName("DisplayLongitude")]
    public float? DisplayLongitude { get; set; } = null;

    [JsonPropertyName("ImageHeight")]
    public int? ImageHeight { get; set; } = null;

    [JsonPropertyName("ImageURL")]
    public string ImageURL { get; set; } = string.Empty;

    [JsonPropertyName("ImageWidth")]
    public int? ImageWidth { get; set; } = null;

    [JsonPropertyName("IsActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("OwnerURL")]
    public object? OwnerURL { get; set; } = null;

    [JsonPropertyName("Region")]
    public string Region { get; set; } = string.Empty;

    [JsonPropertyName("SortOrder")]
    public int? SortOrder { get; set; } = null;

    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;
}

public class Cameralocation
{
    [JsonPropertyName("Description")]
    public object? Description { get; set; } = null;

    [JsonPropertyName("Direction")]
    public string Direction { get; set; } = string.Empty;

    [JsonPropertyName("Latitude")]
    public float? Latitude { get; set; } = null;

    [JsonPropertyName("Longitude")]
    public float? Longitude { get; set; } = null;

    [JsonPropertyName("MilePost")]
    public int? MilePost { get; set; } = null;

    [JsonPropertyName("RoadName")]
    public string RoadName { get; set; } = string.Empty;
}
