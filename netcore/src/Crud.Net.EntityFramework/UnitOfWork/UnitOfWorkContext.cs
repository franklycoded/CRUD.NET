using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Crud.Net.EntityFramework.UnitOfWork
{
    /// <summary>
    /// <see cref="IUnitOfWorkContext" />
    /// </summary>
    public class UnitOfWorkContext : IUnitOfWorkContext
    {
        private DbContext _context;
        
        /// <summary>
        /// Creates a new instance of the UnitOfWorkContext
        /// </summary>
        /// <param name="context">The EntityFramework db context</param>
        public UnitOfWorkContext(DbContext context){
            if(context == null) throw new ArgumentNullException(nameof(context));
            
            _context = context;
        }
        
        /// <summary>
        /// <see cref="IUnitOfWorkContext.Context" />
        /// </summary>
        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// <see cref="IUnitOfWorkContext.SaveChanges" />
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// <see cref="IUnitOfWorkContext.SaveChangesAsync" />
        /// </summary>
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(_context != null) _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
