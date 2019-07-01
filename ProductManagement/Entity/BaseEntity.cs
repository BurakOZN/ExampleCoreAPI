using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Entity
{
    [DataContract]
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
        }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public DateTime CreateAt { get; set; }
        [DataMember]
        public string CreateBy { get; set; }
        [DataMember]
        public DateTime UpdateAt { get; set; }
        [DataMember]
        public string UpdateBy { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
