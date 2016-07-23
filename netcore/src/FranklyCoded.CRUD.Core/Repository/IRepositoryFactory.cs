using FranklyCoded.CRUD.Core.DataModel;

namespace FranklyCoded.CRUD.Core.Repository
{
    /// <summary>
    /// Creates repositories for the given TContext
    /// </summary>
    public interface IRepositoryFactory<TContext>
    {
        /// <summary>
        /// Creates a new repository that acts on the TEntity objects via ordinary CRUD operations
        /// </summary>
        /// <returns>The repository for TEntity objects</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
    }
}
