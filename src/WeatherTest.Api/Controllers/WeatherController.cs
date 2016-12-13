using Microsoft.AspNetCore.Mvc;
using System;
using WeatherTest.Api.Models;
using WeatherTest.Services;
using WeatherTest.Services.Models;

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
            if (tempUnit != "fahrenheit" && tempUnit != "celsius") return new BadRequestObjectResult("Unknown temp unit: " + (nameof(tempUnit)));
            if (speedUnit != "mph" && speedUnit != "kph") return new BadRequestObjectResult("Unknown speed unit: " + (nameof(speedUnit)));

            try
            {
                var result = _weatherHandler.Handle(new WeatherRequest
                {
                    Location = location,
                    TemperatureUnit = tempUnit == "fahrenheit" ? TemperatureUnit.Fahrenheit : TemperatureUnit.Celsius,
                    SpeedUnit = speedUnit == "mph" ? SpeedUnit.Mph : SpeedUnit.Kph
                });

                return new OkObjectResult(new WeatherResult
                {
                    Location = result.Location,
                    Temperature = result.AggregatedTemperature,
                    Windspeed = result.AggregatedWindSpeed
                });
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
