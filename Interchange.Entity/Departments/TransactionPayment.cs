using System;

namespace Interchange.Entity
{
    public class TransactionPayment
    {
        public int InterchangeId { get; set; }
        public string ReceiptNbr { get; set; }
        public string PaymentDate { get; set; }
        public string Message { get; set; }
    }
}
