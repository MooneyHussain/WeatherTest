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

            throw new Exception();
        }
    }
}
