using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class SystemInterfaces
    {
        [DataMember]
        public SystemInterface[] SystemInterface;
    }

    [DataContract]
    public class SystemInterface
    {
        [DataMember]
        public string Description;
        [DataMember]
        public string ID;
        [DataMember]
        public string Type;
        [DataMember]
        public string DatasourceName;
        [DataMember]
        public string DatabaseName;
        [DataMember]
        public string LoginName;
        [DataMember]
        public string LoginPassword;
        [DataMember]
        public string InterfaceDefinition;
        [DataMember]
        public SystemInterfaceItem[] SystemInterfaceItem;
    }

    [DataContract]
    public class SystemInterfaceItem
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;
    }
}
