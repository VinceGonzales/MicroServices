using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class InquiryRequest
    {
        [DataMember]
        public string WorkgroupID;
        [DataMember]
        public string UserID;
        [DataMember]
        public string BannerID;
        [DataMember]
        public string TransType;
        [DataMember]
        public string CoreFileEffDT;
        [DataMember]
        public SystemInterfaces SystemInterfaces;
        [DataMember]
        public string QuerySourcePage;
        [DataMember]
        public QueryKeys QueryKeys;
        //public XmlSchema GetSchema() { return null; }
        //public void ReadXml(XmlReader reader) { }
        //public void WriteXml(XmlWriter writer) { }
    }
    
    [DataContract]
    public class QueryKeys
    {
        [DataMember]
        public QueryKey[] QueryKey;
    }

    [DataContract]
    public class QueryKey
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;
    }
}
