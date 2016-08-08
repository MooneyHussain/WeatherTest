namespace WeatherTest.Services.Models
{
    public class WeatherRequest
    {
        public string Location { get; set; }
        public TemperatureUnit TemperatureUnit { get; set; }
        public SpeedUnit SpeedUnit { get; set; }
    }
}
