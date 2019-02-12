using Interchange.Entity;
using System.ServiceModel;

namespace Interchange.WCF
{
    [ServiceContract]
    public interface IHubExternal
    {
        [OperationContract]
        InquiryResponse3 InquiryRequest3Operation(InquiryRequest myInquiryRequest);
        [OperationContract]
        UpdateResponse UpdateRequestOperation(UpdateRequest myUpdateRequest);
        [OperationContract]
        VoidResponse VoidRequestOperation(VoidRequest myVoidRequest);
    }
}
