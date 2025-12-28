namespace SPC.Infrastructure.WSDOT.Mappers;

using SPC.Infrastructure.WSDOT.Models.Report;
using SPC.Domain.Models.WSDOT.Report;

internal static class WSDOTReportMapper
{
    internal static WSDOTReport ToDomain(this WSDOTReportDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new WSDOTReport
        {
            DateUpdated = dto.DateUpdated,
            ElevationInFeet = dto.ElevationInFeet,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            MountainPassId = dto.MountainPassId,
            MountainPassName = dto.MountainPassName,
            RestrictionOne = dto.RestrictionOne?.ToDomain(),
            RestrictionTwo = dto.RestrictionTwo?.ToDomain(),
            RoadCondition = dto.RoadCondition,
            TemperatureInFahrenheit = dto.TemperatureInFahrenheit,
            TravelAdvisoryActive = dto.TravelAdvisoryActive,
            WeatherCondition = dto.WeatherCondition
        };
    }

    internal static IEnumerable<WSDOTReport> ToDomain(this IEnumerable<WSDOTReportDto> dtos)
    {
        if (dtos == null)
            throw new ArgumentNullException(nameof(dtos));

        return dtos.Select(dto => dto.ToDomain());
    }

    private static WSDOTReportRestrictionOne ToDomain(this WSDOTReportRestrictionOneDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new WSDOTReportRestrictionOne
        {
            RestrictionText = dto.RestrictionText,
            TravelDirection = dto.TravelDirection
        };
    }

    private static WSDOTReportRestrictionTwo ToDomain(this WSDOTReportRestrictionTwoDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new WSDOTReportRestrictionTwo
        {
            RestrictionText = dto.RestrictionText,
            TravelDirection = dto.TravelDirection
        };
    }

}