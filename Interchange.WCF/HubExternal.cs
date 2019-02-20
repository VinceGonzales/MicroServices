using Interchange.Entity;
using System.ServiceModel;

namespace Interchange.WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class HubExternal : IHubExternal
    {
        private IFactory factory;

        public HubExternal(IFactory repoFactory)
        {
            factory = repoFactory;
        }

        public InquiryResponse3 InquiryRequest3Operation(InquiryRequest myInquiryRequest)
        {
            InquiryResponse3 myInquiryResponse = factory.GetRequest(myInquiryRequest);
            return myInquiryResponse;
        }
        public UpdateResponse UpdateRequestOperation(UpdateRequest myUpdateRequest)
        {
            UpdateResponse myUpdateResponse = factory.PayTransaction(myUpdateRequest);
            return myUpdateResponse;
        }
        public VoidResponse VoidRequestOperation(VoidRequest myVoidRequest)
        {
            VoidResponse myVoidResponse = factory.VoidTransaction(myVoidRequest);
            return myVoidResponse;
        }
    }
}