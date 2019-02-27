using Interchange.Data;
using Interchange.Entity;
using System;
using System.Linq;

namespace Interchange.WCF
{
    public class Factory : Repository<IDataService>, IFactory
    {
        private AbstractFacade facade;

        public Factory(AbstractFacade face)
        {
            facade = face;
        }

        public InquiryResponse3 GetRequest(InquiryRequest request)
        {
            InquiryResponse3 response = new InquiryResponse3();

            base.deptNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_deptid")).value;
            base.appNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_appid")).value;
            if (base.deptNo == Util.GetDeptId(Department.LADBS))
            {
                if (base.appNo.Equals("002"))
                {
                    using (facade)
                    {
                        base.service = new Finance("DefaultConnectionString", facade);
                        response = base.ProcessInquiry(request);
                    }
                }
                else if (base.appNo.Equals("001"))
                {
                    using (facade)
                    {
                        base.service = new Permit("DefaultConnectionString", facade);
                        response = base.ProcessInquiry(request);
                    }
                }
                else if (base.appNo.Equals("003"))
                {
                    using (facade)
                    {
                        base.service = new GenericDepartment("DefaultConnectionString", facade);
                        response = base.ProcessInquiry(request);
                    }
                }
                else
                {
                    ReturnBadRequest(response);
                }
            }
            else
            {
                ReturnBadRequest(response);
            }
            return response;
        }
        public UpdateResponse PayTransaction(UpdateRequest request)
        {
            throw new NotImplementedException();
        }
        public VoidResponse VoidTransaction(VoidRequest request)
        {
            throw new NotImplementedException();
        }

        #region Private Methods
        private void ReturnBadRequest(InquiryResponse3 response)
        {
            response.Type = Interchange.Data.ResponseType.Failure.ToString();
            response.ErrorCode = "400";
            response.ErrorSummary = "Bad Request";
            response.ErrorDetail = "The server cannot process the request due to faulty data structure";
        }
        #endregion
    }
    public interface IFactory
    {
        InquiryResponse3 GetRequest(InquiryRequest request);
        UpdateResponse PayTransaction(UpdateRequest request);
        VoidResponse VoidTransaction(VoidRequest request);
    }
}