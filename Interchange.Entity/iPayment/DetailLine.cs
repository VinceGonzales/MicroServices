using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class DetailLine
    {
        [DataMember]
        public List<DetailLineItem> DetailLineItem;
    }

    [DataContract]
    public class DetailLineItem
    {
        [XmlAttribute]
        public string name;
        [XmlText]
        public string value;

        public DetailLineItem(string n, string v)
        {
            name = n;
            value = v;
        }

        public DetailLineItem() { }
    }
}
