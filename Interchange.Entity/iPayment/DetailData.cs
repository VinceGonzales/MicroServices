using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interchange.Entity
{
    [DataContract]
    public class DetailData
    {
        [DataMember]
        public List<Group> Group;
    }

    [DataContract]
    public class DetailDataXXX
    {
        [DataMember]
        public List<GroupXXX> GroupXXX;
    }
}
