using Capgemini.Infrastructure.Context.Interfaces;
using Capgemini.Infrastructure.Data.Entity;
using FluentValidation.Results;
using System.Linq;

namespace Capgemini.Infrastructure.Application.Services
{
    public class ServiceBase<T> where T : EntityBase<T>
    {
        protected readonly IServiceContext _serviceContext;

        public ServiceBase(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public bool ValidateEntity(T domain)
        {
            domain.IsValid();
            if (domain?.ValidationResult?.Errors.Any() == true)
            {
                foreach (var domainErro in domain.ValidationResult.Errors)
                    AddNotification(domainErro);
            }
            return IsValidOperation;
        }

        private void AddNotification(ValidationFailure error)
        {
            AddNotification(error.ErrorMessage);
        }

        public void AddNotification(string message) => _serviceContext.AddNotification(message);

        public bool IsValidOperation => !_serviceContext.HasNotification();
    }
}