using FluentAssertions;
using System;
using WeatherTest.Services;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class WeatherCalculatorTests
    {
        [Fact]
        public void GivenNullModelThenThrowArgumentNullException()
        {
            var weatherCalculator = new WeatherCalculator();

            Action act = () => weatherCalculator.Calculate(null);

            act.ShouldThrow<ArgumentNullException>();
        }

    }
}
