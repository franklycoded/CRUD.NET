using System;
using System.Runtime.Serialization;

namespace FranklyCoded.CRUD.Core.DataContract
{
    public interface ICrudDto
    {
        [DataMember]
        long Id { get; set; }
        
        [DataMember]
        DateTime CreatedUTC { get; set; }
        
        [DataMember]
        DateTime ModifiedUTC { get; set; }
    }
}
