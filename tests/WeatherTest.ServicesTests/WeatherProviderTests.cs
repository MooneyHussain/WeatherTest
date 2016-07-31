using FluentAssertions;
using System;
using WeatherTest.Services;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class WeatherProviderTests
    {
        [Fact]
        public void GivenNullWeatherSourcesThenThrowArgumentNullException()
        {
            Action act = () => new WeatherProvider(null);

            act.ShouldThrow<ArgumentNullException>();
        }      
    }
}
