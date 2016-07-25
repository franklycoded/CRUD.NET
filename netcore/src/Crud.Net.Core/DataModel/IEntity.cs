using System;

namespace Crud.Net.Core.DataModel
{
    /// <summary>
    /// Interface for Crud.Net data model entities
    /// Forces the data model to have Id, creation and modification date fiels for every resource
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the id of the entity
        /// </summary>
        /// <returns>The id of the entity</returns>
        long Id { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the entity
        /// </summary>
        /// <returns>The creation date of the entity</returns>
        DateTime CreatedUTC { get; set; }
        
        /// <summary>
        /// Gets or sets the last modified date of the entity
        /// </summary>
        /// <returns>The last modified date of the entity</returns>
        DateTime ModifiedUTC { get; set; }
    }
}
