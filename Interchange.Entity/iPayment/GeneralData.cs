using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class GeneralData
    {
        [DataMember]
        public GeneralLineItem[] GeneralLineItem;
    }

    [DataContract]
    public class GeneralLineItem
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;
    }
}
