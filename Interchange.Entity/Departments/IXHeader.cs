using System;

namespace Interchange.Entity
{
    public class IXHeader
    {
        public string Header_ApplicationNbr { get; set; }
        public string Header_DeptId { get; set; }
        public string Header_AppId { get; set; }
        public string Header_Barcode { get; set; }
        public bool Header_IsBldCrd { get; set; }
        public bool Header_IsBldPermit { get; set; }
        public int Header_NoOfPermit { get; set; }
        public string Header_ReceiptRefNbr { get; set; }
        public int Header_RPRNbr { get; set; }
        public string Header_BuildingCardNbr { get; set; }
        public string Header_Grouping { get; set; }
        public string Header_CustomerNbr { get; set; }
        public string Header_Origin { get; set; }
        public decimal Header_FeeAmt { get; set; }
        public string Header_Message { get; set; }
        public DateTime? Header_PaymentDate { get; set; }
    }
}
