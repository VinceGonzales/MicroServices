using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class Transactions
    {
        [XmlAttribute]
        public string Count;
        [DataMember]
        public Transaction[] Transaction;
    }

    [DataContract]
    public class Transaction
    {
        [DataMember]
        public TransactionItem[] TransactionItem;
    }

    [DataContract]
    public class TransactionItem
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;
    }
}
