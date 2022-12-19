using Capgemini.Weather.Domain.Entities;
using System.Threading.Tasks;

namespace Capgemini.Weather.Data.Repositories.Interfaces
{
    public interface IWeatherRepository
    {
        Task<WeatherForecast> AddAsync(WeatherForecast weather);
    }
}