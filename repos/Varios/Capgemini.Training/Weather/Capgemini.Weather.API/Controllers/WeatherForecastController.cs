using Capgemini.Infrastructure.Context.Interfaces;
using Capgemini.Infrastructure.Controller;
using Capgemini.Weather.Application.Models;
using Capgemini.Weather.Application.Services.Interfaces;
using Capgemini.Weather.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capgemini.Weather.API.Controllers
{
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServiceContext context, IWeatherService weatherService) : base(context)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WeatherModel model)
        {
            return ServiceResponse(await _weatherService.AddAsync(model));
        }
    }
}