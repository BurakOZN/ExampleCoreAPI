using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Entity
{
    [DataContract]
    public class Product : BaseEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }

        //User FK
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
