using System;

namespace Interchange.Entity
{
    public class MatchInfo : IMatchInfo
    {
        public string Header_CustomerNbr { get; set; }
        public string Header_DeptId { get; set; }
        public string Header_AppId { get; set; }
        public string Header_ApplicationNbr { get; set; }
        public string DisplayName { get; set; }
        public string DisplayAddress { get; set; }
        public string Name_FName { get; set; }
        public string Name_LName { get; set; }
    }
    public interface IMatchInfo : IPacket
    {
        string Header_CustomerNbr { get; set; }
        string DisplayName { get; set; }
        string DisplayAddress { get; set; }
        string Name_FName { get; set; }
        string Name_LName { get; set; }
    }
}
