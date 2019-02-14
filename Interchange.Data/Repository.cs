using Interchange.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Data
{
    public class Repository<T> where T : class, IDataService
    {
        private AbstractFacade dal;
        private T service;
        private IInquiryMatch result;
        public Repository(AbstractFacade facade, T svc)
        {
            dal = facade;
            service = svc;
        }

        public IInquiryMatch GetRequest(InquiryRequest request)
        {
            QueryKey key1 = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_applicationnbr"));
            QueryKey key2 = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_customernbr"));

            if (key1 != null)
            {
                string deptNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_deptid")).value;
                string appNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_appid")).value;
                string transNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_applicationnbr")).value;

                result = service.GetTransaction(deptNo, appNo, transNo);
            }
            else if (key2 != null)
            {
                string customerNumber = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_customernbr")).value;
                //result = GetByAcctNumber(customerNumber);
            }
            else
            {
                string businessName = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_businessname")) != null ? inq.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_businessname")).value : string.Empty;
                string lastName = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_lname")) != null ? inq.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_lname")).value : string.Empty;
                string firstName = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_fname")) != null ? inq.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("name_fname")).value : string.Empty;

                //result = GetSearchResult(businessName, lastName, firstName);
            }

            return result;
        }
        public InquiryResponse3 GetResponse()
        {
            InquiryResponse3 response = new InquiryResponse3();

            return response;
        }
    }
}
