﻿using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherTest.Services.Models;

namespace WeatherTest.Services
{
    public class BbcWeatherSource : IWeatherSource
    {
        private readonly string _bbcUrl = "http://localhost:5000";

        public async Task<WeatherSourceResult> Get(string location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_bbcUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"/weather/{location}");
                    response.EnsureSuccessStatusCode();

                    var stringResponse = await response.Content.ReadAsStringAsync();

                    return CreateResult(stringResponse);                                       
                }
                catch (HttpRequestException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
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
