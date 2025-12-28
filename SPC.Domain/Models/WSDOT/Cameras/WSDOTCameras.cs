namespace SPC.Domain.Models.WSDOT.Cameras;

public class WSDOTCamera
{
    public int? CameraID { get; set; } = null;
    public Cameralocation? CameraLocation { get; set; } = null;
    public object? CameraOwner { get; set; } = null;
    public object? Description { get; set; } = null;
    public float? DisplayLatitude { get; set; } = null;
    public float? DisplayLongitude { get; set; } = null;
    public int? ImageHeight { get; set; } = null;
    public string ImageURL { get; set; } = string.Empty;
    public int? ImageWidth { get; set; } = null;
    public bool IsActive { get; set; }
    public object? OwnerURL { get; set; } = null;
    public string Region { get; set; } = string.Empty;
    public int? SortOrder { get; set; } = null;
    public string Title { get; set; } = string.Empty;
}

public class Cameralocation
{
    public object? Description { get; set; } = null;
    public string Direction { get; set; } = string.Empty;
    public float? Latitude { get; set; } = null;
    public float? Longitude { get; set; } = null;
    public int? MilePost { get; set; } = null;
    public string RoadName { get; set; } = string.Empty;
}
