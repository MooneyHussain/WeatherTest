using System.Collections.Generic;

namespace WeatherTest.Services.Models
{
    public class WeatherProviderResult
    {
         public string Location { get; set; }
         public List<double> TemperatureCelsius { get; set; }
         public List<double> TemperatureFahrenheit { get; set; }
         public List<double> WindSpeedKph { get; set; }
         public List<double> WindSpeedMph { get; set; }
    }
}
