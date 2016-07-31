using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherTest.Services;
using Xunit;

namespace WeatherTest.ServicesTests
{
    public class WeatherProviderTests
    {
        public class Constructor
        {
            [Fact]
            public void GivenNullWeatherSourcesThenThrowArgumentNullException()
            {
                Action act = () => new WeatherProvider(null);

                act.ShouldThrow<ArgumentNullException>();
            }
        }

        public class Retrieve
        {
            private string _location = "dorset";
            private List<IWeatherSource> _sources;

            public Retrieve()
            {
                _sources = new List<IWeatherSource>
                {
                    new Mock<IWeatherSource>().Object
                };
            }

            [Fact]
            public void GivenNullLocationThenThrowArgumentNullException()
            {
                var provider = new WeatherProvider(_sources);

                Action act = () => provider.Retrieve(null);

                act.ShouldThrow<ArgumentNullException>();
            }


        }        
    }
}
