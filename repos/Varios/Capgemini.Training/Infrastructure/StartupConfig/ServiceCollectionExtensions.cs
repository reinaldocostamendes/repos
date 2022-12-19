using Capgemini.Infrastructure.Context;
using Capgemini.Infrastructure.Context.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Capgemini.Infrastructure.StartupConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceContext(this IServiceCollection services)
        {
            services.AddScoped<IServiceContext, ServiceContext>();
        }
    }
}