using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Crud.Net.EntityFramework.UnitOfWork
{
    /// <summary>
    /// Abstraction of top of the EntityFramework DbContext to support the unit of work pattern
    /// </summary>
    public interface IUnitOfWorkContext : IDisposable
    {
        /// <summary>
        /// Gets the EntityFramework DbContext
        /// </summary>
        /// <returns></returns>
        DbContext Context { get; }
        
        /// <summary>
        /// Saves changes to the EntityFramework DbContext
        /// </summary>
        void SaveChanges();
        
        /// <summary>
        /// Saves changes to the EntityFramework DbContext asynchronously
        /// </summary>
        /// <returns>The number of persisted entities</returns>
        Task<int> SaveChangesAsync();
    }
}
