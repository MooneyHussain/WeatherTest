using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public interface IProvideWeather
    {
        WeatherProviderResult Retrieve(string location);
    }
}
