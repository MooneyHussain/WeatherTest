using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public class BbcWeatherSource : IWeatherSource
    {
        private readonly IRestClient _client;
        private readonly string _bbcUrl = "http://localhost:5000";

        public BbcWeatherSource(IRestClient client)
        {
            _client = client;
            _client.BaseUrl = new Uri(_bbcUrl);
        }

        public async Task<WeatherSourceResult> Get(string location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            try
            {
                var request = new RestRequest($"/weather/{location}", Method.GET);
                var response = await _client.ExecuteGetTaskAsync(request);

                return CreateResult(response.Content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("failure when requesting to bbc weather source", ex);
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
