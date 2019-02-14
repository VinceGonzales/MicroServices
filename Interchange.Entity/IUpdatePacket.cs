using System;

namespace Interchange.Entity
{
    public interface IUpdatePacket
    {
        decimal Detail_PayAmount { get; set; }
        string ReceiptNbr { get; set; }
        DateTime? Header_PaymentDate { get; set; }
    }
}
