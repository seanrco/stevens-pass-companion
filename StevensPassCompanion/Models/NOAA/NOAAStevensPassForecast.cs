using Newtonsoft.Json;

namespace StevensPassCompanion.Models.NOAA;

public class NOAAStevensPassForecast
{
    [JsonProperty("context")]
    public object[] context { get; set; }
    [JsonProperty("type")]
    public string type { get; set; }
    [JsonProperty("geometry")]
    public Geometry geometry { get; set; }
    [JsonProperty("properties")]
    public Properties properties { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public float[][][] coordinates { get; set; }
}

public class Properties
{
    public DateTime updated { get; set; }
    public string units { get; set; }
    public string forecastGenerator { get; set; }
    public DateTime generatedAt { get; set; }
    public DateTime updateTime { get; set; }
    public string validTimes { get; set; }
    public Elevation elevation { get; set; }
    public Period[] periods { get; set; }
}

public class Elevation
{
    public string unitCode { get; set; }
    public float value { get; set; }
}

public class Period
{
    public int number { get; set; }
    public string name { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public bool isDaytime { get; set; }
    public int temperature { get; set; }
    public string temperatureUnit { get; set; }
    public string temperatureTrend { get; set; }
    public string windSpeed { get; set; }
    public string windDirection { get; set; }
    public string icon { get; set; }
    public string shortForecast { get; set; }
    public string detailedForecast { get; set; }
}