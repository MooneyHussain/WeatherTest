using Microsoft.AspNetCore.Mvc;
using System;
using WeatherTest.Services;

namespace WeatherTest.Api.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHandleWeather _weatherHandler;

        public WeatherController(IHandleWeather weatherHandler)
        {
            if (weatherHandler == null)
                throw new ArgumentNullException(nameof(weatherHandler));

            _weatherHandler = weatherHandler;
        }

        [HttpGet, Route("[controller]/{location}/{temperatureUnit}/{speedUnit}")]
        public IActionResult Get(string location, string temperatureUnit, string speedUnit)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));
            if (temperatureUnit == null) throw new ArgumentNullException(nameof(temperatureUnit));
            if (speedUnit == null) throw new ArgumentNullException(nameof(speedUnit));

            throw new NotImplementedException();             
        }
    }
}
