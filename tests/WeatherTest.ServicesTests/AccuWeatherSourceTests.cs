using FluentAssertions;
using System;
using WeatherTest.Services;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class AccuWeatherSourceTests
    {
        [Fact]
        public void GivenNullLocationThenThrowArgumentNullException()
        {
            var source = new AccuWeatherSource();

            Action act = () => source.Get(null).Wait();

            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
