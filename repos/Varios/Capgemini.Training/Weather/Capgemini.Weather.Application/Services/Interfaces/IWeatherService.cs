using Capgemini.Weather.Application.Models;
using Capgemini.Weather.Domain.Entities;
using System.Threading.Tasks;

namespace Capgemini.Weather.Application.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherForecast> AddAsync(WeatherModel model);
    }
}