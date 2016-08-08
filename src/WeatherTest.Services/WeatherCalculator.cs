using System;
using System.Collections.Generic;
using System.Linq;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public class WeatherCalculator : ICalculateWeather
    {
        public CalculatedWeatherResult Calculate(WeatherProviderResult model, WeatherRequest criteria)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));

            var aggregatedTemp = CalculateTemperature(criteria.TemperatureUnit, model);

            return new CalculatedWeatherResult
            {
                Location = criteria.Location,
                AggregatedTemperature = aggregatedTemp,
                TemperatureUnit = criteria.TemperatureUnit
            };
        }

        private double CalculateTemperature(TemperatureUnit unit, WeatherProviderResult model)
        {
            var averagedCelsius = GetAverageResult(model.TemperatureCelsius);
            var averagedFahrenheit = GetAverageResult(model.TemperatureFahrenheit);

            if (unit == TemperatureUnit.Celsius)
            {
                var celsius = (averagedFahrenheit - 32) * 5 / 9;
                return (averagedCelsius + celsius) / 2;                
            }

            if (unit == TemperatureUnit.Fahrenheit)
            {
                var fahrenheit = (averagedCelsius * 1.8) + 32;
                return (averagedFahrenheit + fahrenheit) / 2;
            }

            throw new Exception("Unknown Temperature Unit");
        }
               
        private double GetAverageResult(List<double> numbers)
        {
            return numbers.Average();
        }
    }
}
