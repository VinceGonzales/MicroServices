using Interchange.Data;
using Interchange.Entity;
using System.Linq;

namespace Interchange.WCF
{
    public class Factory
    {
        private IRepository<DataService> repo;
        private IDataService service;

        public InquiryResponse3 GetRequest(InquiryRequest req)
        {
            string deptNo = req.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_deptid")).value;
            string appNo = req.QueryKeys.QueryKey.FirstOrDefault(x => x.name.ToLower().Equals("header_appid")).value;
            if (deptNo == Util.GetDeptId(Department.LADBS))
            {
                if (appNo.Equals("002"))
                {
                    using (AbstractFacade facade = new AdoFacade())
                    {
                        service = new Finance(facade);
                        repo = new Repository<Finance>(service);
                    }
                }
                else if (appNo.Equals("001"))
                {
                    //
                }
            }
        }

        #region Private Methods
        
        #endregion
    }
    public interface IFactory
    {
        InquiryResponse3 GetRequest(InquiryRequest req);
        UpdateResponse PayTransaction(UpdateRequest req);
        VoidResponse VoidTransaction(VoidRequest req);
    }
}