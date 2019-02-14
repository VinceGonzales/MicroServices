using Interchange.Entity;
using System;

namespace Interchange.Data
{
    public interface IDataService
    {
        IInquiryMatch GetTransaction(string deptNo, string appNo, string transNo);
        string UpdatePayment(string deptNo, string appNo, string transNo, string receiptNo, decimal payAmt, DateTime paymentDt);
    }
}
