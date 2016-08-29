using FluentAssertions;
using Moq;
using System;
using WeatherTest.Api.Controllers;
using WeatherTest.Services;
using Xunit;

namespace WeatherTest.ApiTests
{
    public class WeatherControllerTests
    {
        private Mock<IHandleWeather> _weatherHandler;
        private string _location = "bournemouth";
        private string _tempUnit = "celsius";
        private string _speedUnit = "mph";

        public WeatherControllerTests()
        {
            _weatherHandler = new Mock<IHandleWeather>();
        }

        [Fact]
        public void GivenNullWeatherHandleThenThrowArgumentNullException()
        {
            Action act = ()  => new WeatherController(null);

            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void GivenNullLocationThenThrowArgumentNullException()
        {
            var controller = new WeatherController(_weatherHandler.Object);

            Action act = () => controller.Get(null, _tempUnit, _speedUnit);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GivenNullTemperatureUnitThenThrowArgumentNullException()
        {
            var controller = new WeatherController(_weatherHandler.Object);

            Action act = () => controller.Get(_location, null, _speedUnit);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GivenNullSpeedUnitThenThrowArgumentNullException()
        {
            var controller = new WeatherController(_weatherHandler.Object);

            Action act = () => controller.Get(_location, _tempUnit, null);

            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
