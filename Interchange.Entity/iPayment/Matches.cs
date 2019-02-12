using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class Matches
    {
        [XmlAttribute]
        [DataMember]
        public String Count;
        [DataMember]
        public List<Match> Match;
    }

    [DataContract]
    public class Match
    {
        [DataMember]
        public List<MatchItem> MatchItem { get; set; }
    }

    [DataContract]
    public class MatchItem
    {
        [XmlAttribute]
        [DataMember]
        public string name;
        [XmlText]
        [DataMember]
        public string value;

        public MatchItem(string n, string v)
        {
            name = n;
            value = v;
        }

        public MatchItem() { }
    }
}
