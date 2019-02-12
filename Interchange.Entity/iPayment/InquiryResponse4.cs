using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class InquiryResponse4
    {
        [XmlAttribute]
        [DataMember]
        public string Type;
        [DataMember]
        public GeneralData GeneralData;
        [DataMember]
        public DetailDataXXX DetailDataXXX;
        [DataMember]
        public Matches Matches;
        [DataMember]
        public string ErrorCode;
        [DataMember]
        public string ErrorSummary;
        [DataMember]
        public string ErrorDetail;

        //public XmlSchema GetSchema() { return null; }
        //public void ReadXml(XmlReader reader) { }
        //public void WriteXml(XmlWriter writer) { }
    }
}
