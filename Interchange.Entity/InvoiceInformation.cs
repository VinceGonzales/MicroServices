using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Entity
{
    public class InvoiceInformation : IInvoiceInformation
    {
        public string Header_ApplicationNbr { get; set; }
        public decimal Header_FeeAmt { get; set; }
        public decimal Header_AmtPaid { get; set; }
        public decimal Header_AmtDue { get; set; }
        public decimal Header_Balance { get; set; }
    }
    public interface IInvoiceInformation
    {
        string Header_ApplicationNbr { get; set; }
        decimal Header_FeeAmt { get; set; }
        decimal Header_AmtPaid { get; set; }
        decimal Header_AmtDue { get; set; }
        decimal Header_Balance { get; set; }
    }
}
