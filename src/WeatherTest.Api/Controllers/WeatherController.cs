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

        [HttpGet, Route("api/v1/weather/{location}")]
        public IActionResult Get(string location, [FromQuery] string tempUnit, [FromQuery] string speedUnit)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));
            if (tempUnit == null) throw new ArgumentNullException(nameof(tempUnit));
            if (speedUnit == null) throw new ArgumentNullException(nameof(speedUnit));

            throw new NotImplementedException();             
        }
    }
}
