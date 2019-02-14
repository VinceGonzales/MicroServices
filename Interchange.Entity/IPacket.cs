using System;

namespace Interchange.Entity
{
    public interface IPacket
    {
        string Header_DeptId { get; set; }
        string Header_AppId { get; set; }
        string Header_ApplicationNbr { get; set; }
    }
}
