using System;

namespace Interchange.Entity
{
    public class PermitItem : IPermitItem
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
        public decimal Detail_PayAmount { get; set; }
    }
    public interface IPermitItem : IInvoiceItem
    {
        decimal Detail_PayAmount { get; set; }
    }
}
