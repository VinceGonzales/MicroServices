using System;

namespace Interchange.Entity
{
    public interface IInterchangeDetail
    {
        decimal AmtPaid { get; set; }
        decimal Balance { get; set; }
        string BalanceSheet { get; set; }
        DateTime? CreateDate { get; set; }
        string CreatedBy { get; set; }
        string Dept { get; set; }
        string Description { get; set; }
        decimal FeeAmt { get; set; }
        string FeeCat { get; set; }
        string FeeCod { get; set; }
        string FeeGrp { get; set; }
        string FeePeriod { get; set; }
        decimal FeeSort { get; set; }
        string FeeType { get; set; }
        string Fund { get; set; }
        int IntrChgId { get; set; }
        int LineItemNbr { get; set; }
        string PmtStatus { get; set; }
        string RevenueCode { get; set; }
        string SubRevenueCode { get; set; }
        string TransRefNbr { get; set; }
        DateTime? UDFDate1 { get; set; }
        DateTime? UDFDate2 { get; set; }
        DateTime? UDFDate3 { get; set; }
        DateTime? UDFDate4 { get; set; }
        DateTime? UDFDate5 { get; set; }
        int? UDFNum1 { get; set; }
        int? UDFNum2 { get; set; }
        int? UDFNum3 { get; set; }
        int? UDFNum4 { get; set; }
        int? UDFNum5 { get; set; }
        string UDFText1 { get; set; }
        string UDFText2 { get; set; }
        string UDFText3 { get; set; }
        string UDFText4 { get; set; }
        string UDFText5 { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}