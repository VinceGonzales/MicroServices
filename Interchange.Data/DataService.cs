using Interchange.Entity;
using System;

namespace Interchange.Data
{
    public abstract class DataService
    {
        protected AbstractFacade dal;

        public DataService(AbstractFacade facade)
        {
            dal = facade;
        }

        public abstract IInquiryMatch GetByAcctNumber(string deptNo, string appNo, string customerNo);

        public abstract IInquiryMatch GetSearchResult(string deptNo, string appNo, string business, string lastname, string firstname);

        public abstract IInquiryMatch GetTransaction(string deptNo, string appNo, string transNo);

        public abstract InquiryResponse3 ParseResult(IInquiryMatch match);

        public abstract string UpdatePayment(string deptNo, string appNo, string transNo, string receiptNo, decimal payAmt, DateTime paymentDt);

        public abstract string VoidPayment(string receiptNo);
    }
}
