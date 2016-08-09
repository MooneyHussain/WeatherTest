using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public interface ICalculateWeather
    {
        CalculatedWeatherResult Calculate(WeatherProviderResult model, WeatherRequest criteria);
    }
}
