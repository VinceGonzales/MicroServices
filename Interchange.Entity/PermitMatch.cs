using System;
using System.Collections.Generic;

namespace Interchange.Entity
{
    public class PermitMatch : IPermitMatch
    {
        public IPermitHeader PermitInfo { get; set; }
        public List<IPermitItem> PermitItems { get; set; }
        public ICustomerInformation CustomerInfo { get; set; }
        public List<IInvoiceInformation> InvoiceList { get; set; }
        public List<IInvoiceItem> InvoiceItemList { get; set; }
        public List<IMatchInfo> MatchList { get; set; }
        public MatchType ResultType { get; set; }
        public string WarningMessage { get; set; }

        public PermitMatch()
        {
            PermitInfo = new PermitHeader();
            PermitItems = new List<IPermitItem>();
            CustomerInfo = new CustomerInformation();
            InvoiceList = new List<IInvoiceInformation>();
            InvoiceItemList = new List<IInvoiceItem>();
            MatchList = new List<IMatchInfo>();
        }
    }
    public interface IPermitMatch : IInquiryMatch
    {
        IPermitHeader PermitInfo { get; set; }
        List<IPermitItem> PermitItems { get; set; }
    }
}
