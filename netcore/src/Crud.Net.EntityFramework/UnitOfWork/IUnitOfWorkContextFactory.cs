namespace Crud.Net.EntityFramework.UnitOfWork
{
    /// <summary>
    /// Factory to create IUnitOfWorkContexts
    /// </summary>
    public interface IUnitOfWorkContextFactory
    {
        /// <summary>
        /// Creates or retrieves a cached IUnitOfWorkContext of the specified type
        /// </summary>
        /// <returns>The IUnitOfWorkContext of the specified type</returns>
        IUnitOfWorkContext GetContext<TContext>();
    }
}
