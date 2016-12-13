using FluentAssertions;
using Moq;
using RestSharp;
using System;
using System.Net.Http;
using WeatherTest.Services;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class BbcWeatherSourceTests
    {
        [Fact]
        public void GivenNullLocationThenThrowArgumentNullException()
        {
            var client = new Mock<IRestClient>();
            var source = new BbcWeatherSource(client.Object);

            Action act = () => source.Get(null).Wait();

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async void GivenInvocationThenReturnWeatherSourceResult()
        {
            var location = "bmouth";                        
            var json = JsonBuilder(new TestJsonModel
            {
                Location = location,
                TemperatureCelsius = 100,
                TemperatureFahrenheit = 200,
                WindSpeedKph = 10,
                WindSpeedMph = 5
            });

            var client = new Mock<IRestClient>();
            client.Setup(c => c.ExecuteGetTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(new RestResponse
            {
                Content = json
            });

            var source = new BbcWeatherSource(client.Object);
            var result = await source.Get(location);

            result.TemperatureCelsius.Should().Be(100);
            result.TemperatureFahrenheit.Should().Be(200);
            result.WindSpeedKph.Should().Be(10);
            result.WindSpeedMph.Should().Be(5);
        }

        [Fact]
        public void GivenInvocationWhenThereIsHttpRequestExceptionThenThrowException()
        {
            var location = "bmouth";
            var client = new Mock<IRestClient>();
            client.Setup(c => c.ExecuteGetTaskAsync(It.IsAny<IRestRequest>()))
                .ThrowsAsync(new HttpRequestException());

            var source = new BbcWeatherSource(client.Object);

            Action act = () => source.Get(location).Wait(); ;

            act.ShouldThrow<Exception>();
        }

        private string JsonBuilder(TestJsonModel model)
        {
            return "{" + $"\"Location\": \"{model.Location}\"," + $"\"TemperatureFahrenheit\": {model.TemperatureFahrenheit}," +
                $"\"WindSpeedKph\": {model.WindSpeedKph}," + $"\"WindSpeedMph\": {model.WindSpeedMph},"
                + $"\"TemperatureCelsius\": {model.TemperatureCelsius}" + "}";
        }
    }

    public class TestJsonModel
    {
        public string Location { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public double WindSpeedKph { get; set; }
        public double WindSpeedMph { get; set; }
        public double TemperatureCelsius { get; set; }
    }
}
