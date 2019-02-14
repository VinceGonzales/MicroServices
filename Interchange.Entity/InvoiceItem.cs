using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Entity
{
    public class InvoiceItem : IInvoiceItem
    {
        public string Header_ApplicationNbr { get; set; }
        public int Detail_FeeSort { get; set; }
        public string Detail_Description { get; set; }
        public decimal Detail_FeeAmt { get; set; }
        public decimal Detail_AmtPaid { get; set; }
        public decimal Detail_Balance { get; set; }
        public string Detail_Dept { get; set; }
        public string Detail_Fund { get; set; }
        public string Detail_RevenueCode { get; set; }
        public string Detail_SubRevenueCode { get; set; }
        public string Detail_BalanceSheet { get; set; }
    }
    public interface IInvoiceItem
    {
        string Header_ApplicationNbr { get; set; }
        int Detail_FeeSort { get; set; }
        string Detail_Description { get; set; }
        decimal Detail_FeeAmt { get; set; }
        decimal Detail_AmtPaid { get; set; }
        decimal Detail_Balance { get; set; }
        string Detail_Dept { get; set; }
        string Detail_Fund { get; set; }
        string Detail_RevenueCode { get; set; }
        string Detail_SubRevenueCode { get; set; }
        string Detail_BalanceSheet { get; set; }
    }
}
