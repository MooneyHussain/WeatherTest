using FluentAssertions;
using System;
using System.Collections.Generic;
using WeatherTest.Services;
using WeatherTest.Services.Models;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class WeatherCalculatorTests
    {
        private readonly string _location = "dorset";

        [Fact]
        public void GivenNullModelThenThrowArgumentNullException()
        {
            var weatherCalculator = new WeatherCalculator();

            Action act = () => weatherCalculator.Calculate(null, new WeatherRequest());

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GivenNullWeatherRequestCriteriaThenThrowArgumentNullException()
        {
            var weatherCalculator = new WeatherCalculator();

            Action act = () => weatherCalculator.Calculate(new WeatherProviderResult(), null);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GivenCalculateIsInvokedWhenTemperatureUnitIsCelsiusThenReturnCorrectAggregatedResult()
        {
            var model = new WeatherProviderResult
            {
                Location = _location,
                TemperatureCelsius = new List<double> { 10 },
                TemperatureFahrenheit = new List<double> { 68 }
            };

            var criteria = new WeatherRequest
            {
                Location = _location,
                TemperatureUnit = TemperatureUnit.Celsius
            };

            var weatherCalculator = new WeatherCalculator();

            var result = weatherCalculator.Calculate(model, criteria);

            result.AggregatedTemperature.Should().Be(15);
            result.TemperatureUnit.Should().Be(TemperatureUnit.Celsius);
        }

        [Fact]
        public void GivenCalculateIsInvokedWhenTemperatureUnitIsaFahrenheitThenReturnCorrectAggregatedResult()
        {
            var model = new WeatherProviderResult
            {
                Location = _location,
                TemperatureCelsius = new List<double> { 10 },
                TemperatureFahrenheit = new List<double> { 68 }
            };

            var criteria = new WeatherRequest
            {
                Location = _location,
                TemperatureUnit = TemperatureUnit.Fahrenheit
            };

            var weatherCalculator = new WeatherCalculator();

            var result = weatherCalculator.Calculate(model, criteria);

            result.AggregatedTemperature.Should().Be(59);
            result.TemperatureUnit.Should().Be(TemperatureUnit.Fahrenheit);
        }
    }
}
