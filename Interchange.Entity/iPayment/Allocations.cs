using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    [Serializable]
    [XmlType(Namespace = "http://tempuri.org/")]
    public class Allocations
    {
        [XmlAttribute]
        public string Count { get; set; }
        [DataMember]
        public List<AllocationItem> Allocation { get; set; }
    }

    [DataContract]
    [Serializable]
    [XmlType(Namespace = "http://tempuri.org/")]
    public class AllocationItem
    {
        [XmlAttribute]
        public string name { get; set; }
        [DataMember]
        [XmlText]
        public string value { get; set; }
    }
}
