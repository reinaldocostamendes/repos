using Capgemini.Weather.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Capgemini.Weather.Domain.Validations
{
    public class WeatherForecastValidation : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastValidation()
        {
            RuleFor(x => x.Date).NotNull()
                .WithMessage("Date can't be null");

            RuleFor(x => x.TemperatureC).NotNull()
                .WithMessage("Temperature Celsius can't be null");

            RuleFor(x => x.TemperatureF).NotNull()
                .WithMessage("Temperature Fahrenheit can't be null");

            RuleFor(x => x.Summary).NotNull()
                .WithMessage("Summary can't be null");
        }
    }
}