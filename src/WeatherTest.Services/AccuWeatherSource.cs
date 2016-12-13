using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public class AccuWeatherSource : IWeatherSource
    {
        private readonly string _accUrl = "http://localhost:5001";

        public async Task<WeatherSourceResult> Get(string location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            var client = new RestClient();
            client.BaseUrl = new Uri(_accUrl);

            try
            {
                var request = new RestRequest($"/{location}", Method.GET);
                var response = await client.ExecuteGetTaskAsync(request);

                return CreateResult(response.Content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("failure when requesting to accu weather source", ex);
            }
        }

        private WeatherSourceResult CreateResult(string response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            return JsonConvert.DeserializeObject<WeatherSourceResult>(response);
        }
    }
}
