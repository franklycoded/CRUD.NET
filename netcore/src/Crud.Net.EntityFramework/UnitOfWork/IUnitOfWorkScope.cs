using Crud.Net.Core.UnitOfWork;

namespace Crud.Net.EntityFramework.UnitOfWork
{
    /// <summary>
    /// Creates and maintains cached versions of UnitOfWorkContexts. Useful when data changes to one or multiple data sources have to be made but restricted to a single connection per data store.
    /// </summary>
    public interface IUnitOfWorkScope : IUnitOfWork
    {
        /// <summary>
        /// Gets a new UnitOfWorkContext from the context cache.
        /// If the context with the specified type doesn't exist, it creates a new one and adds it to the cache
        /// </summary>
        /// <returns>The UnitOfWorkContext with the specified type</returns>
        IUnitOfWorkContext GetContext<TContext>();
    }
}
