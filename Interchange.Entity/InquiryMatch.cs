﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Entity
{
    public class InquiryMatch : IInquiryMatch
    {
        public ICustomerInformation CustomerInfo { get; set; }
        public List<IInvoiceInformation> InvoiceList { get; set; }
        public List<IInvoiceItem> InvoiceItemList { get; set; }
        public List<IMatchInfo> MatchList { get; set; }
        public MatchType ResultType { get; set; }
        public string WarningMessage { get; set; }

        public InquiryMatch()
        {
            CustomerInfo = new CustomerInformation();
            InvoiceList = new List<IInvoiceInformation>();
            InvoiceItemList = new List<IInvoiceItem>();
            MatchList = new List<IMatchInfo>();
        }
    }
    public interface IInquiryMatch : IMatch
    {
        ICustomerInformation CustomerInfo { get; set; }
        List<IInvoiceInformation> InvoiceList { get; set; }
        List<IInvoiceItem> InvoiceItemList { get; set; }
    }
}
