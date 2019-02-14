using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Entity
{
    public class CustomerInformation : ICustomerInformation
    {
        public string Header_CustomerNbr { get; set; }
        public string DisplayName { get; set; }
        public string DisplayAddress { get; set; }
        public string Header_DeptId { get; set; }
        public string Header_AppId { get; set; }
        public string Header_ApplicationNbr { get; set; }
    }
    public interface ICustomerInformation : IPacket
    {
        string Header_CustomerNbr { get; set; }
        string DisplayName { get; set; }
        string DisplayAddress { get; set; }
    }
}
