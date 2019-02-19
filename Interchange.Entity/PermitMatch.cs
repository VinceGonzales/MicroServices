using System;
using System.Collections.Generic;

namespace Interchange.Entity
{
    public class PermitMatch : InquiryMatch, IPermitMatch
    {
        public IPermitHeader PermitInfo { get; set; }
        public List<IInvoiceItem> PermitItems { get; set; }

        public PermitMatch() : base()
        {
            PermitInfo = new PermitHeader();
            PermitItems = new List<IInvoiceItem>();
        }
    }
    public interface IPermitMatch : IInquiryMatch
    {
        IPermitHeader PermitInfo { get; set; }
        List<IInvoiceItem> PermitItems { get; set; }
    }
}
