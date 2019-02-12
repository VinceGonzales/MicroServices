using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class COREFile
    {
        [DataMember]
        public string POSTDT;
        [DataMember]
        public COREFileItem[] COREFileItem;
        [DataMember]
        public COREEvents[] COREEvents;
    }

    [DataContract]
    public class COREFileItem
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;
    }

    [DataContract]
    public class COREEvents
    {
        [DataMember]
        public COREEvent[] COREEvent;
    }

    [DataContract]
    public class COREEvent
    {
        [DataMember]
        public string ReceiptReferenceNbr;
        [DataMember]
        public COREEventItem[] COREEventItem;
        [DataMember]
        public Transactions[] Transactions;
        [DataMember]
        public Tenders[] Tenders;
        [DataMember]
        public TTA[] TTAMAPPING;
    }

    [DataContract]
    public class COREEventItem
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;
    }
}
