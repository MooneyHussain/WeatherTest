using FluentAssertions;
using Moq;
using System;
using WeatherTest.Services;
using WeatherTest.Services.Models;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class WeatherHandlerTests
    {        
        public class Constructor
        {
            private readonly Mock<IProvideWeather> _weatherProvider;
            private readonly Mock<ICalculateWeather> _weatherCalculator;

            public Constructor()
            {
                _weatherProvider = new Mock<IProvideWeather>();
                _weatherCalculator = new Mock<ICalculateWeather>();
            }

            [Fact]
            public void GivenNullWeatherProviderThenThrowArgumentNullException()
            {
                Action act = () => new WeatherHandler(null, _weatherCalculator.Object);

                act.ShouldThrow<ArgumentNullException>();
            }

            [Fact]
            public void GivenNullWeatherCalculatorThenThrowArgumentNullException()
            {
                Action act = () => new WeatherHandler(_weatherProvider.Object, null);

                act.ShouldThrow<ArgumentNullException>();
            }
        }

        public class Handle
        {
            private readonly Mock<IProvideWeather> _weatherProvider;
            private readonly Mock<ICalculateWeather> _weatherCalculator;

            public Handle()
            {
                _weatherProvider = new Mock<IProvideWeather>();
                _weatherCalculator = new Mock<ICalculateWeather>();
            }

            [Fact]
            public void GivenNullWeatherRequestThenThrowArgumentNullException()
            {
                var handler = new WeatherHandler(_weatherProvider.Object, _weatherCalculator.Object);

                Action act = () => handler.Handle(null);

                act.ShouldThrow<ArgumentNullException>();
            }

            [Fact]
            public void GivenNullLocationThenThrowArgumentNullException()
            {
                var request = new WeatherRequest();
                request.Location = null;
                var handler = new WeatherHandler(_weatherProvider.Object, _weatherCalculator.Object);

                Action act = () => handler.Handle(request);

                act.ShouldThrow<ArgumentNullException>();
            }
        }
    }
}
