using System;
using System.Threading.Tasks;

namespace Crud.Net.Core.UnitOfWork
{
    /// <summary>
    /// Interface to save changes made against the managed UnitOfWorkContexts
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves the changes across all managed UnitOfWorkContexts 
        /// </summary>
        void SaveChanges();
        
        /// <summary>
        /// Saves the changes asynchronously across all managed UnitOfWorkContexts
        /// </summary>
        /// <returns>The number of entities persisted</returns>
        Task<int> SaveChangesAsync();
    }
}
