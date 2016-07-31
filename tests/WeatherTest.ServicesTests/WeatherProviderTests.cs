using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using WeatherTest.Services;
using WeatherTest.Services.Models;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class WeatherProviderTests
    {
        public class Constructor
        {
            [Fact]
            public void GivenNullWeatherSourcesThenThrowArgumentNullException()
            {
                Action act = () => new WeatherProvider(null);

                act.ShouldThrow<ArgumentNullException>();
            }
        }

        public class Retrieve
        {
            private string _location = "dorset";
            private List<IWeatherSource> _weatherSources;

            public Retrieve() 
            {
                _weatherSources = new List<IWeatherSource>();
            }

            [Fact]
            public void GivenNullLocationThenThrowArgumentNullException()
            {
                var provider = new WeatherProvider(_weatherSources);

                Action act = () => provider.Retrieve(null);

                act.ShouldThrow<ArgumentNullException>();
            }

            [Fact]
            public void GivenWeatherSourcesThenAddToWeatherResult()
            {
                //TODO: FAILING TEST! 
                var sourceA = new Mock<IWeatherSource>();
                var sourceB = new Mock<IWeatherSource>();

                sourceA.Setup(s => s.Get(It.IsAny<string>())).ReturnsAsync(new WeatherSourceResult
                {
                    Location = _location,
                    TemperatureCelsius = 13,
                    WindSpeedKph = 24
                });

                sourceB.Setup(s => s.Get(It.IsAny<string>())).ReturnsAsync(new WeatherSourceResult
                {
                    Location = _location,
                    TemperatureFahrenheit = 55.4,
                    WindSpeedMph = 15
                });

                _weatherSources.Add(sourceA.Object);
                _weatherSources.Add(sourceB.Object);

                var provider = new WeatherProvider(_weatherSources);

                var result = provider.Retrieve(_location);

                result.Location.Should().Be(_location);
                result.TemperatureCelsius.Should().Equal(13);
            }
        }        
    }
}
