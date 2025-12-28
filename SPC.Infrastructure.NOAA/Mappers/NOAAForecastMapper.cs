using SPC.Domain.Models.NOAA.Forecast;
using SPC.Infrastructure.NOAA.Models.Forecast;

namespace SPC.Infrastructure.NOAA.Mappers;

internal static class NOAAForecastMapper
{
    internal static NOAAForecast ToDomain(this NOAAForecastDto dto)
    {
        return new NOAAForecast
        {
            Context = dto.Context,
            Type = dto.Type,
            Geometry = dto.Geometry?.ToDomain(),
            Properties = dto.Properties?.ToDomain()
        };
    }

    private static Geometry ToDomain(this GeometryDto dto)
    {
        return new Geometry
        {
            Type = dto.Type,
            Coordinates = dto.Coordinates
        };
    }

    private static Properties ToDomain(this PropertiesDto dto)
    {
        return new Properties
        {
            Updated = dto.Updated,
            Units = dto.Units,
            ForecastGenerator = dto.ForecastGenerator,
            GeneratedAt = dto.GeneratedAt,
            UpdateTime = dto.UpdateTime,
            ValidTimes = dto.ValidTimes,
            Elevation = dto.Elevation?.ToDomain(),
            Periods = dto.Periods?.Select(p => p.ToDomain()).ToArray()
        };
    }

    private static Elevation ToDomain(this ElevationDto dto)
    {
        return new Elevation
        {
            UnitCode = dto.UnitCode,
            Value = dto.Value
        };
    }

    private static Period ToDomain(this PeriodDto dto)
    {
        return new Period
        {
            Number = dto.Number,
            Name = dto.Name,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            IsDaytime = dto.IsDaytime,
            Temperature = dto.Temperature,
            TemperatureUnit = dto.TemperatureUnit,
            TemperatureTrend = dto.TemperatureTrend,
            WindSpeed = dto.WindSpeed,
            WindDirection = dto.WindDirection,
            Icon = dto.Icon,
            ShortForecast = dto.ShortForecast,
            DetailedForecast = dto.DetailedForecast
        };
    }

}