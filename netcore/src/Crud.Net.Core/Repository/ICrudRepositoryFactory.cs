using Crud.Net.Core.DataModel;

namespace Crud.Net.Core.Repository
{
    /// <summary>
    /// Creates repositories for the given TContext
    /// </summary>
    public interface ICrudRepositoryFactory<TContext>
    {
        /// <summary>
        /// Creates a new repository that acts on the TEntity objects via CRUD operations
        /// </summary>
        /// <returns>The repository for TEntity objects</returns>
        ICrudRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
    }
}
