using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class VoidResponse
    {
        [XmlAttribute]
        [DataMember]
        public string Type;
        [DataMember]
        public string ErrorCode;
        [DataMember]
        public string ErrorSummary;
        [DataMember]
        public string ErrorDetail;
    }
}
