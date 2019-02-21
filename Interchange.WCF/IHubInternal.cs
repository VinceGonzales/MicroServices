using Interchange.Entity;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interchange.WCF
{
    [ServiceContract]
    public interface IHubInternal
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "header", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostHeader(IXHeader header);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "detail/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostDetail(IXDetail detail, string id);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "name/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostName(IXName name, string id);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "address/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostAddress(IXAddress address, string id);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "details/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostDetails(IEnumerable<IXDetail> details, string id);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "clean/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string DeleteTransaction(string id);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getpay/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        TransactionPayment GetPayment(string id);
    }
}
