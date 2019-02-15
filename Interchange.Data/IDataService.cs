using Interchange.Entity;
using System;

namespace Interchange.Data
{
    public interface IDataService
    {
        IInquiryMatch GetTransaction(string deptNo, string appNo, string transNo);
        IInquiryMatch GetByAcctNumber(string deptNo, string appNo, string customerNo);
        IInquiryMatch GetSearchResult(string deptNo, string appNo, string business, string lastname, string firstname);
        InquiryResponse3 ParseResult(IInquiryMatch match);
        string UpdatePayment(string deptNo, string appNo, string transNo, string receiptNo, decimal payAmt, DateTime paymentDt);
        string VoidPayment(string receiptNo);
    }
}
