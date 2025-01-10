namespace SPC.Core.Models.WSDOT.Cameras;

public class WSDOTCamera
{
    public int CameraID { get; set; }
    public Cameralocation CameraLocation { get; set; }
    public object CameraOwner { get; set; }
    public object Description { get; set; }
    public float DisplayLatitude { get; set; }
    public float DisplayLongitude { get; set; }
    public int ImageHeight { get; set; }
    public string ImageURL { get; set; }
    public int ImageWidth { get; set; }
    public bool IsActive { get; set; }
    public object OwnerURL { get; set; }
    public string Region { get; set; }
    public int SortOrder { get; set; }
    public string Title { get; set; }
}

public class Cameralocation
{
    public object Description { get; set; }
    public string Direction { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public int MilePost { get; set; }
    public string RoadName { get; set; }
}
