using System;

namespace Interchange.Entity
{
    public interface IInterchangeHeader
    {
        decimal AmtPaid { get; set; }
        int AppId { get; set; }
        string ApplicationNbr { get; set; }
        decimal Balance { get; set; }
        string BarCode { get; set; }
        string BuildingCardNbr { get; set; }
        DateTime? CreateDate { get; set; }
        string CreatedBy { get; set; }
        string CustomerNbr { get; set; }
        string DeptId { get; set; }
        decimal FeeAmt { get; set; }
        string Grouping { get; set; }
        int IntrChgId { get; set; }
        bool IsBldCrd { get; set; }
        bool IsBldPermit { get; set; }
        int NoOfPermits { get; set; }
        string Origin { get; set; }
        string ReceiptRefNbr { get; set; }
        string RPRNbr { get; set; }
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
        string Warning { get; set; }
    }
}