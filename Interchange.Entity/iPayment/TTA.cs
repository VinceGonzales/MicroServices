using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class TTA
    {
        [DataMember]
        public string TRANNBR;
        [DataMember]
        public string TNDRNBR;
        [DataMember]
        public string AMOUNT;
    }
}
