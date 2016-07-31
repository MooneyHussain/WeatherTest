using System.Threading.Tasks;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    interface IWeatherSource
    {
        Task<WeatherSourceResult> Get(string location);
    }
}
