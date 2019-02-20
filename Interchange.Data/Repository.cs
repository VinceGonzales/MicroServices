using Interchange.Entity;
using System;
using System.Linq;

namespace Interchange.Data
{
    public class Repository<T> : IRepository<T> 
        where T : class, IDataService
    {
        protected T service;
        protected string deptNo;
        protected string appNo;

        public InquiryResponse3 ProcessInquiry(InquiryRequest request)
        {
            IInquiryMatch result = null;
            QueryKey key1 = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_applicationnbr"));

            if (key1 != null)
            {
                string transNo = key1.value;
                result = service.GetTransaction(deptNo, appNo, transNo);
            }
            else
            {
                QueryKey key2 = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_customernbr"));
                if (key2 != null)
                {
                    string customerNumber = key2.value;
                    result = service.GetByAcctNumber(deptNo, appNo, customerNumber);
                }
                else
                {
                    string businessName = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_businessname")) != null ? request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_businessname")).value : string.Empty;
                    string lastName = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_lname")) != null ? request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_lname")).value : string.Empty;
                    string firstName = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_fname")) != null ? request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_fname")).value : string.Empty;

                    result = service.GetSearchResult(deptNo, appNo, businessName, lastName, firstName);
                }
            }

            InquiryResponse3 response = service.ParseResult(result);
            return response;
        }
        public UpdateResponse ProcessUpdate(UpdateRequest request)
        {
            throw new NotImplementedException();
        }
        public VoidResponse ProcessVoid(VoidRequest request)
        {
            throw new NotImplementedException();
        }
    }
    public interface IRepository<T> where T : class, IDataService
    {
        InquiryResponse3 ProcessInquiry(InquiryRequest request);
        UpdateResponse ProcessUpdate(UpdateRequest request);
        VoidResponse ProcessVoid(VoidRequest request);
    }
}
