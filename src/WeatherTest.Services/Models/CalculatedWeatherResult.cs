namespace WeatherTest.Services.Models
{
    public class CalculatedWeatherResult
    {
        public string Location { get; set; }
        public double AggregatedTemperature { get; set; }
        public double AggregatedWindSpeed { get; set; }
        public TemperatureUnit TemperatureUnit { get; set; }
        public SpeedUnit SpeedUnit { get; set; }
    }
}
