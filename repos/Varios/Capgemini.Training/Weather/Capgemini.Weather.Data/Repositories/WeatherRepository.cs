using Capgemini.Infrastructure.Data.Repositories;
using Capgemini.Weather.Data.Repositories.Interfaces;
using Capgemini.Weather.Domain.Entities;
using System.Threading.Tasks;

namespace Capgemini.Weather.Data.Repositories
{
    public class WeatherRepository : RepositoryBase<WeatherForecast>, IWeatherRepository
    {
        public async Task<WeatherForecast> AddAsync(WeatherForecast weather)
        {
            return weather;
        }
    }
}