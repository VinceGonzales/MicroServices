﻿using Interchange.Entity;
using System.Linq;

namespace Interchange.Data
{
    public class Repository<T> where T : class, IDataService
    {
        private T service;
        public Repository(T svc)
        {
            service = svc;
        }

        public InquiryResponse3 GetRequest(InquiryRequest request)
        {
            IInquiryMatch result = null;
            QueryKey key1 = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_applicationnbr"));
            string deptNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_deptid")).value;
            string appNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_appid")).value;

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
    }
}