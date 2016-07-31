namespace WeatherTest.Services.Models
{
    public class WeatherSourceResult
    {
        string Location { get; set; }
        double TemperatureCelsius { get; set; }
        double TemperatureFahrenheit { get; set; }
        double WindSpeedKph { get; set; }
        double WindSpeedMph { get; set; }
    }
}
