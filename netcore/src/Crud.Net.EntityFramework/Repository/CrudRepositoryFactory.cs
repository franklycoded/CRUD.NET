using System;
using Crud.Net.Core.DataModel;
using Crud.Net.Core.Repository;
using Crud.Net.EntityFramework.UnitOfWork;

namespace Crud.Net.EntityFramework.Repository
{
    /// <summary>
    /// <see cref="IRepositoryFactory" />
    /// </summary>
    public class CrudRepositoryFactory<TContext> : ICrudRepositoryFactory<TContext>
    {
        protected readonly IUnitOfWorkScope _unitOfWorkScope;
        
        /// <summary>
        /// Creates a new instance of the Repository Factory
        /// </summary>
        /// <param name="unitOfWorkScope">The unit of work scope to be used to retrieve UnitOfWorkContexts</param>
        public CrudRepositoryFactory(IUnitOfWorkScope unitOfWorkScope)
        {
            if(unitOfWorkScope == null) throw new ArgumentNullException(nameof(unitOfWorkScope));
            
            _unitOfWorkScope = unitOfWorkScope;
        }

        /// <summary>
        /// <see cref="IRepositoryFactory.GetRepository<TEntity>" />
        /// </summary>
        public ICrudRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            return new CrudRepository<TEntity>(_unitOfWorkScope.GetContext<TContext>());
        }
    }
}
