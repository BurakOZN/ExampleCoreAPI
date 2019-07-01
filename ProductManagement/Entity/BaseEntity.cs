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
        public DateTime CreatAt { get; set; }
        [DataMember]
        public string CreatBy { get; set; }
        [DataMember]
        public DateTime UpdateAt { get; set; }
        [DataMember]
        public string UpdateBy { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
