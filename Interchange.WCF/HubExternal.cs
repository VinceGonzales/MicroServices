using Interchange.Entity;
using System;
using System.Linq;
using System.ServiceModel;

namespace Interchange.WCF
{
    public class HubExternal : IHubExternal
    {
        public InquiryResponse3 InquiryRequest3Operation(InquiryRequest myInquiryRequest)
        {
            InquiryResponse3 myInquiryResponse = new InquiryResponse3();
            return myInquiryResponse;
        }
        public UpdateResponse UpdateRequestOperation(UpdateRequest myUpdateRequest)
        {
            UpdateResponse myUpdateResponse = new UpdateResponse();
            return myUpdateResponse;
        }
        public VoidResponse VoidRequestOperation(VoidRequest myVoidRequest)
        {
            VoidResponse myVoidResponse = new VoidResponse();
            return myVoidResponse;
        }
    }
}