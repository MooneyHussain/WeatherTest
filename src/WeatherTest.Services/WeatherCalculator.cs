using System;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public class WeatherCalculator : ICalculateWeather
    {
        public void Calculate(WeatherProviderResult model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            throw new NotImplementedException();
        }
    }
}
