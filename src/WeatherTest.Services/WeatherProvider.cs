using System;
using System.Collections.Generic;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public class WeatherProvider : IProvideWeather
    {
        private readonly IEnumerable<IWeatherSource> _weatherSources;

        public WeatherProvider(IEnumerable<IWeatherSource> weatherSources)
        {
            if (weatherSources == null)
                throw new ArgumentNullException(nameof(weatherSources));

            _weatherSources = weatherSources;
        }

        public WeatherProviderResult Retrieve(string location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            var weatherResults = new List<WeatherSourceResult>();

            foreach (var source in _weatherSources)
            {
                var result = source.Get(location).Result;
                weatherResults.Add(result);
            }

            return CreateResult(weatherResults, location);
        }

        private WeatherProviderResult CreateResult(IEnumerable<WeatherSourceResult> weatherSources, string location)
        {
            var providerResult = new WeatherProviderResult();
            providerResult.Location = location;

            foreach (var result in weatherSources)
            {
                providerResult.TemperatureCelsius.Add(result.TemperatureCelsius);
                providerResult.TemperatureFahrenheit.Add(result.TemperatureCelsius);
                providerResult.WindSpeedKph.Add(result.WindSpeedKph);
                providerResult.WindSpeedMph.Add(result.WindSpeedMph);
            }

            return providerResult;
        }
    }
}
