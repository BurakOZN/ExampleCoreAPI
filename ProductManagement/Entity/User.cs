using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entity
{
    [DataContract]
    public class User : BaseEntity
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

        //Product FK
        [DataMember]
        public virtual List<Product> Products { get; set; }
    }
}
