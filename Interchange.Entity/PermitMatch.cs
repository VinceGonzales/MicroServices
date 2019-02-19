using System;
using System.Collections.Generic;

namespace Interchange.Entity
{
    public class PermitMatch : InquiryMatch, IPermitMatch
    {
        public IPermitHeader PermitInfo { get; set; }
        public List<IPermitItem> PermitItems { get; set; }

        public PermitMatch() : base()
        {
            PermitInfo = new PermitHeader();
            PermitItems = new List<IPermitItem>();
        }
    }
    public interface IPermitMatch : IInquiryMatch
    {
        IPermitHeader PermitInfo { get; set; }
        List<IPermitItem> PermitItems { get; set; }
    }
}
