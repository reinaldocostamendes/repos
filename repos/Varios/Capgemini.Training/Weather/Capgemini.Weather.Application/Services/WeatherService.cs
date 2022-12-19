using Capgemini.Infrastructure.Application.Services;
using Capgemini.Infrastructure.Context.Interfaces;
using Capgemini.Weather.Application.Models;
using Capgemini.Weather.Application.Services.Interfaces;
using Capgemini.Weather.Data.Repositories.Interfaces;
using Capgemini.Weather.Domain.Entities;
using System.Threading.Tasks;

namespace Capgemini.Weather.Application.Services
{
    public class WeatherService : ServiceBase<WeatherForecast>, IWeatherService
    {
        private IWeatherRepository _weatherRepository;

        public WeatherService(IServiceContext serviceContext, IWeatherRepository weatherRepository) : base(serviceContext)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<WeatherForecast> AddAsync(WeatherModel model)
        {
            ///TODO: Fazer MAP de Model para Domain para validar.
            var domain = new WeatherForecast()
            {
                Date = System.DateTime.UtcNow,
                TemperatureC = -1
            };
            ValidateEntity(domain);
            AddNotification("Erro de negocio");
            if (!IsValidOperation)
                return null;
            return await _weatherRepository.AddAsync(domain);
        }
    }
}