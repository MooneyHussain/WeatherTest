using System;

namespace WeatherTest.Services
{
    public class WeatherHandler
    {
        private readonly IProvideWeather _weatherProvider;
        private readonly ICalculateWeather _weatherCalculator;

        public WeatherHandler(IProvideWeather weatherProvider, ICalculateWeather weatherCalculator)
        {
            if (weatherProvider == null)
                throw new ArgumentNullException(nameof(weatherProvider));

            if (weatherCalculator == null)
                throw new ArgumentNullException(nameof(weatherCalculator));

            _weatherProvider = weatherProvider;
            _weatherCalculator = weatherCalculator;
        }
    }
}
