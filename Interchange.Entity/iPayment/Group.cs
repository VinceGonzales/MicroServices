using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class Group
    {
        [XmlAttribute]
        [DataMember]
        public string ID;
        [XmlAttribute]
        [DataMember]
        public string BankRuleID;
        [DataMember]
        public int count;
        [DataMember]
        public List<DetailLine> DetailLine;
    }

    [DataContract]
    public class GroupXXX
    {
        [XmlAttribute]
        [DataMember]
        public IEnumerable<int> result;
    }
}
