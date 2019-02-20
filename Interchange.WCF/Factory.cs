using Interchange.Data;
using Interchange.Entity;
using System;
using System.Linq;

namespace Interchange.WCF
{
    public class Factory : Repository<IDataService>, IFactory
    {
        public InquiryResponse3 GetRequest(InquiryRequest request)
        {
            InquiryResponse3 response = new InquiryResponse3();

            string deptNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_deptid")).value;
            string appNo = request.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_appid")).value;
            if (deptNo == Util.GetDeptId(Department.LADBS))
            {
                if (appNo.Equals("002"))
                {
                    using (AbstractFacade facade = new AdoFacade())
                    {
                        service = new Finance(facade);
                        response = base.ProcessRequest(request);
                    }
                }
                else if (appNo.Equals("001"))
                {
                    using (AbstractFacade facade = new AdoFacade())
                    {
                        service = new Permit(facade);
                        response = base.ProcessRequest(request);
                    }
                }
                else
                {
                    ReturnBadRequest(response);
                }
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