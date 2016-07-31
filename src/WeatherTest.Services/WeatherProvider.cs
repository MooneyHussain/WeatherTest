using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
