namespace SPC.Domain.Models.NOAA.Forecast;

public class NOAAForecast
{
    public object[]? Context { get; set; } = null;
    public string Type { get; set; } = string.Empty;
    public Geometry? Geometry { get; set; } = null;
    public Properties? Properties { get; set; } = null;
}

public class Geometry
{
    public string Type { get; set; } = string.Empty;
    public float[][][]? Coordinates { get; set; } = null;
}

public class Properties
{
    public DateTime? Updated { get; set; } = null;
    public string Units { get; set; } = string.Empty;
    public string ForecastGenerator { get; set; } = string.Empty;
    public DateTime? GeneratedAt { get; set; } = null;
    public DateTime? UpdateTime { get; set; } = null;
    public string ValidTimes { get; set; } = string.Empty;
    public Elevation? Elevation { get; set; } = null;
    public Period[]? Periods { get; set; } = null;
}

public class Elevation
{
    public string UnitCode { get; set; } = string.Empty;
    public float Value { get; set; }
}

public class Period
{
    public int Number { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? StartTime { get; set; } = null;
    public DateTime? EndTime { get; set; } = null;
    public bool IsDaytime { get; set; }
    public int Temperature { get; set; }
    public string TemperatureUnit { get; set; } = string.Empty;
    public string TemperatureTrend { get; set; } = string.Empty;
    public string WindSpeed { get; set; } = string.Empty;
    public string WindDirection { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string ShortForecast { get; set; } = string.Empty;
    public string DetailedForecast { get; set; } = string.Empty;
}