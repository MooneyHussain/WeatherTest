using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    interface ICalculateWeather
    {
        void Calculate(WeatherProviderResult model);
    }
}
