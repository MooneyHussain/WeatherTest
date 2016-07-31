using FluentAssertions;
using System;
using WeatherTest.Services;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class BbcWeatherSourceTests
    {
        [Fact]
        public void GivenNullLocationThenThrowArgumentNullException()
        {
            var source = new BbcWeatherSource();

            Action act = () => source.Get(null).Wait();

            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
