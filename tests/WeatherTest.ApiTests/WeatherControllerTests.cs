using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("invalid")]
        [InlineData("invalid unit")]
        public void GivenInvalidTemperatureUnitThenReturnBadRequest(string value)
        {
            var controller = new WeatherController(_weatherHandler.Object);

            var result = controller.Get(_location, value, _speedUnit);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("invalid")]
        [InlineData("invalid unit")]
        public void GivenInvalidSpeedUnitThenReturnBadRequest(string value)
        {
            var controller = new WeatherController(_weatherHandler.Object);

            var result = controller.Get(_location, _tempUnit, value);

            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
