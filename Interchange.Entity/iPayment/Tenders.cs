using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class Tenders
    {
        [XmlAttribute]
        public string Count;
        [DataMember]
        public Tender[] Tender;
    }

    [DataContract]
    public class Tender
    {
        [DataMember]
        public TenderItem[] TenderItem;
    }

    [DataContract]
    public class TenderItem
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;
    }
}
