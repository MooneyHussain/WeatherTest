using System;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public class WeatherHandler : IHandleWeather
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

        public CalculatedWeatherResult Handle(WeatherRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Location == null)
                throw new ArgumentNullException(nameof(request));

            var source = _weatherProvider.Retrieve(request.Location);

            var result = _weatherCalculator.Calculate(source, request);

            return result;
        }
    }
}
