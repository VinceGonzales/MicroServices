using System;

namespace Interchange.Entity
{
    public class PermitHeader : IPermitHeader
    {
        public string Header_Barcode { get; set; }
        public bool Header_IsBldCrd { get; set; }
        public bool Header_IsBldPermit { get; set; }
        public int Header_NoOfPermit { get; set; }
        public int Header_RPRNbr { get; set; }
        public string Header_BuildingCardNbr { get; set; }
        public string Header_Grouping { get; set; }
        public string Header_Origin { get; set; }
        public string Header_CustomerNbr { get; set; }
        public string DisplayName { get; set; }
        public string DisplayAddress { get; set; }
        public string Header_DeptId { get; set; }
        public string Header_AppId { get; set; }
        public string Header_ApplicationNbr { get; set; }
        public decimal Header_FeeAmt { get; set; }
        public decimal Header_AmtPaid { get; set; }
        public decimal Header_AmtDue { get; set; }
        public decimal Header_Balance { get; set; }
    }
    public interface IPermitHeader : ICustomerInformation
    {
        string Header_Barcode { get; set; }
        bool Header_IsBldCrd { get; set; }
        bool Header_IsBldPermit { get; set; }
        int Header_NoOfPermit { get; set; }
        int Header_RPRNbr { get; set; }
        string Header_BuildingCardNbr { get; set; }
        string Header_Grouping { get; set; }
        string Header_Origin { get; set; }
        decimal Header_FeeAmt { get; set; }
        decimal Header_AmtPaid { get; set; }
        decimal Header_AmtDue { get; set; }
        decimal Header_Balance { get; set; }
    }
}
