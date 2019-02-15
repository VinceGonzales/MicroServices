using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interchange.Entity;

namespace Interchange.Data
{
    public class Finance : DataService, IDataService
    {
        public Finance(AbstractFacade facade) : base(facade)
        { }

        public override IInquiryMatch GetByAcctNumber(string deptNo, string appNo, string customerNo)
        {
            throw new NotImplementedException();
        }

        public override IInquiryMatch GetSearchResult(string deptNo, string appNo, string business, string lastname, string firstname)
        {
            throw new NotImplementedException();
        }

        public override IInquiryMatch GetTransaction(string deptNo, string appNo, string transNo)
        {
            throw new NotImplementedException();
        }

        public override InquiryResponse3 ParseResult(IInquiryMatch match)
        {
            throw new NotImplementedException();
        }

        public override string UpdatePayment(string deptNo, string appNo, string transNo, string receiptNo, decimal payAmt, DateTime paymentDt)
        {
            throw new NotImplementedException();
        }

        public override string VoidPayment(string receiptNo)
        {
            throw new NotImplementedException();
        }
    }
}
