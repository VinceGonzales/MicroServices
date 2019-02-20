using Interchange.Entity;
using System.ServiceModel;

namespace Interchange.WCF
{
    [ServiceContract, XmlSerializerFormat]
    public interface IHubExternal
    {
        [OperationContract, XmlSerializerFormat(Style = OperationFormatStyle.Document)]
        InquiryResponse3 InquiryRequest3Operation(InquiryRequest myInquiryRequest);
        [OperationContract, XmlSerializerFormat(Style = OperationFormatStyle.Document)]
        UpdateResponse UpdateRequestOperation(UpdateRequest myUpdateRequest);
        [OperationContract, XmlSerializerFormat(Style = OperationFormatStyle.Document)]
        VoidResponse VoidRequestOperation(VoidRequest myVoidRequest);
    }
}
