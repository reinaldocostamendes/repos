using Capgemini.Infrastructure.Context.Interfaces;
using Capgemini.Infrastructure.Data.Entity;

namespace Capgemini.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> where T : EntityBase<T>
    {
        protected readonly IServiceContext ServiceContext;
    }
}