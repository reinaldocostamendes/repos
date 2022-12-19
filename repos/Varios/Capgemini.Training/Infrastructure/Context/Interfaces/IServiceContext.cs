using System.Collections.Generic;

namespace Capgemini.Infrastructure.Context.Interfaces
{
    public interface IServiceContext
    {
        IReadOnlyCollection<string> Notifications { get; }

        bool HasNotification();

        void AddNotification(string message);
    }
}