using FluentAssertions;
using Moq;
using System;
using WeatherTest.Services;
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
    }
}
