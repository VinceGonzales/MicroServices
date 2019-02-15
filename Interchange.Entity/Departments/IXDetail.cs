using System;

namespace Interchange.Entity
{
    public class IXDetail
    {
        public int Detail_LineItemNbr { get; set; }
        public string Detail_FeeType { get; set; }
        public string Detail_FeeGrp { get; set; }
        public string Detail_FeeCod { get; set; }
        public string Detail_FeePeriod { get; set; }
        public string Detail_FeeCat { get; set; }
        public string Detail_Dept { get; set; }
        public string Detail_Fund { get; set; }
        public string Detail_RevenueCode { get; set; }
        public string Detail_SubRevenueCode { get; set; }
        public string Detail_BalanceSheet { get; set; }
        public string Detail_Description { get; set; }
        public int Detail_FeeSort { get; set; }
        public string Detail_PmtStatus { get; set; }
        public decimal Detail_FeeAmt { get; set; }
    }
}
