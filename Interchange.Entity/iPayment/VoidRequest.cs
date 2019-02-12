using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class VoidRequest
    {
        [XmlAttribute]
        [DataMember]
        public string Type;
        [DataMember]
        public SystemInterfaces SystemInterfaces;
        [DataMember]
        public COREFile[] COREFile;
        [DataMember]
        public string UpdateReference;
    }
}
