using Capgemini.Infrastructure.Data.Entity;
using Capgemini.Weather.Domain.Validations;
using FluentValidation.Results;
using System;

namespace Capgemini.Weather.Domain.Entities
{
    public class WeatherForecast : EntityBase<WeatherForecast>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public override bool IsValid()
        {
            if (ValidationResult == null)
            {
                var validator = new WeatherForecastValidation();
                ValidationResult = validator.Validate(this);
            }
            return ValidationResult?.IsValid != false;
        }
    }
}