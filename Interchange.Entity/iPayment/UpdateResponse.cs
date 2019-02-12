using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class UpdateResponse
    {
        [XmlAttribute]
        [DataMember]
        public string Type;
        [DataMember]
        public string UpdateReference;
        [DataMember]
        public string ErrorCode;
        [DataMember]
        public string ErrorSummary;
        [DataMember]
        public string ErrorDetail;
    }
}
