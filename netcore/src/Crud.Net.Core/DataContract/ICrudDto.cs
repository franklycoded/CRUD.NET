using System;
using System.Runtime.Serialization;

namespace Crud.Net.Core.DataContract
{
    /// <summary>
    /// Interface for Crud.Net data contracts
    /// </summary>
    public interface ICrudDto
    {
        /// <summary>
        /// Gets or sets the Id of the data contract
        /// </summary>
        [DataMember]
        long Id { get; set; }
        
        /// <summary>
        /// Gets or sets the UTC creation date of the data contract
        /// </summary>
        [DataMember]
        DateTime CreatedUTC { get; set; }
        
        /// <summary>
        /// Gets or setes the UTC modification date of the data contract
        /// </summary>
        [DataMember]
        DateTime ModifiedUTC { get; set; }
    }
}
