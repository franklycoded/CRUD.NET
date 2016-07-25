using System;
using System.Threading.Tasks;
using Crud.Net.Core.DataModel;
using Crud.Net.Core.Repository;
using Crud.Net.EntityFramework.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Crud.Net.EntityFramework.Repository
{
    /// <summary>
    /// EntityFramework-specific, generic repository for CRUD operations
    /// </summary>
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext _context;
        
        /// <summary>
        /// Creates a new instance of the EntityFramework-specific CRUD repository
        /// </summary>
        /// <param name="unitOfWorkContext">The context wrapper that holds the EntityFramework data context</param>
        public CrudRepository(IUnitOfWorkContext unitOfWorkContext)
        {
            if(unitOfWorkContext == null) throw new ArgumentNullException(nameof(unitOfWorkContext));
            
            _context = unitOfWorkContext.Context;
        }

        /// <summary>
        /// <see cref="ICrudRepository.Add" />
        /// </summary>
        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        /// <summary>
        /// <see cref="ICrudRepository.Delete" />
        /// </summary>
        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        /// <summary>
        /// <see cref="ICrudRepository.GetByIdAsync" />
        /// </summary>
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// <see cref="ICrudRepository.Update" />
        /// </summary>
        public TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }
    }
}
