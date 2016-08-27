using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public interface IHandleWeather
    {
        CalculatedWeatherResult Handle(WeatherRequest request);
    }
}
