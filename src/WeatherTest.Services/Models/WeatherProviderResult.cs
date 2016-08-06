using System.Collections.Generic;

namespace WeatherTest.Services.Models
{
    public class WeatherProviderResult
    {
        private List<double> _temperatureCelsius = new List<double>();
        private List<double> _temperatureFahrenheit = new List<double>();
        private List<double> _windSpeedKph = new List<double>();
        private List<double> _windSpeedMph = new List<double>();

        public string Location { get; set; }

        public List<double> TemperatureCelsius
        {
            get { return _temperatureCelsius; }
            set { _temperatureCelsius = value; }
        }

        public List<double> TemperatureFahrenheit
        {
            get { return _temperatureFahrenheit; }
            set { _temperatureFahrenheit = value; }
        }

        public List<double> WindSpeedKph
        {
            get { return _windSpeedKph; }
            set { _windSpeedKph = value; }
        }

        public List<double> WindSpeedMph
        {
            get { return _windSpeedMph; }
            set { _windSpeedMph = value; }
        }
    }
}
