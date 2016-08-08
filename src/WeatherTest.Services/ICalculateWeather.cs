using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    interface ICalculateWeather
    {
        CalculatedWeatherResult Calculate(WeatherProviderResult model, WeatherRequest criteria);
    }
}
