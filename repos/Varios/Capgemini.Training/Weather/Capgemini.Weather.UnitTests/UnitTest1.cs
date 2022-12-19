using Capgemini.Weather.Application.Models;
using Capgemini.Weather.Application.Services.Interfaces;
using Capgemini.Weather.Domain.Entities;
using Moq;
using Moq.AutoMock;
using System;
using Xunit;

namespace Capgemini.Weather.UnitTests
{
    public class UnitTest1
    {
        public readonly AutoMocker Mocker;

        public UnitTest1()
        {
            Mocker = new AutoMocker();
        }

        [Fact]
        public void Test1()
        {
            var service = Mocker.GetMock<IWeatherService>();
            service.Setup(x => x.AddAsync(It.IsAny<WeatherModel>())).ReturnsAsync(new WeatherForecast());

            service.Verify(s => s.AddAsync(It.IsAny<WeatherModel>()), Times.Once);
        }
    }
}