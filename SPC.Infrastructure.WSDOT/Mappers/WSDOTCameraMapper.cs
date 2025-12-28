namespace SPC.Infrastructure.WSDOT.Mappers;

using SPC.Infrastructure.WSDOT.Models.Cameras;
using SPC.Domain.Models.WSDOT.Cameras;

internal static class WSDOTCameraMapper
{
    internal static WSDOTCamera ToDomain(this WSDOTCameraDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new WSDOTCamera
        {
            CameraID = dto.CameraID,
            CameraLocation = dto.CameraLocation?.ToDomain(),
            CameraOwner = dto.CameraOwner,
            Description = dto.Description,
            DisplayLatitude = dto.DisplayLatitude,
            DisplayLongitude = dto.DisplayLongitude,
            ImageHeight = dto.ImageHeight,
            ImageURL = dto.ImageURL,
            ImageWidth = dto.ImageWidth,
            IsActive = dto.IsActive,
            OwnerURL = dto.OwnerURL,
            Region = dto.Region,
            SortOrder = dto.SortOrder,
            Title = dto.Title
        };
    }

    internal static IEnumerable<WSDOTCamera> ToDomain(this IEnumerable<WSDOTCameraDto> dtos)
    {
        if (dtos == null)
            throw new ArgumentNullException(nameof(dtos));

        return dtos.Select(dto => dto.ToDomain());
    }

    private static Cameralocation ToDomain(this CameralocationDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Cameralocation
        {
            Description = dto.Description,
            Direction = dto.Direction,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            MilePost = dto.MilePost,
            RoadName = dto.RoadName
        };
    }


}