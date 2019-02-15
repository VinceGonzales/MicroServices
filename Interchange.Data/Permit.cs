using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interchange.Entity;

namespace Interchange.Data
{
    public class Permit : DataService, IDataService
    {
        public Permit(AbstractFacade facade) : base(facade)
        { }

        public override IInquiryMatch GetByAcctNumber(string deptNo, string appNo, string customerNo)
        {
            throw new NotImplementedException();
        }

        public override IInquiryMatch GetSearchResult(string deptNo, string appNo, string business, string lastname, string firstname)
        {
            throw new NotImplementedException();
        }

        public override IInquiryMatch GetTransaction(string deptNo, string appNo, string transNo)
        {
            IPermitMatch result = new PermitMatch();

            try
            {
                dal.SetStoredProc("INTERCHANGE.TRANSACTION_PACK.GETTRANSACTIONURL");
                dal.AddParamInString("p_deptNo", deptNo);
                dal.AddParamInString("p_appNo", appNo);
                dal.AddParamInString("p_transNo", transNo);
                dal.AddParamOutString("p_URL", 1000);

                dal.OpenConnection();
                dal.Execute();
                string url = dal.GetParamOutString("p_URL");
                dal.CloseConnection();
                DataContainer data = GetPermit(url);

                if (string.IsNullOrEmpty(data.ErrorMessage))
                {
                    result.PermitInfo.Header_CustomerNbr = data.Header.Header_CustomerNbr;
                    result.PermitInfo.Header_DeptId = deptNo;
                    result.PermitInfo.Header_AppId = appNo;
                    result.PermitInfo.Header_ApplicationNbr = data.Header.Header_ApplicationNbr;
                    result.PermitInfo.DisplayName = data.Information.BusinessName;
                    result.PermitInfo.DisplayAddress = "";
                    result.PermitInfo.Header_Barcode = data.Header.Header_Barcode;
                    result.PermitInfo.Header_IsBldCrd = data.Header.Header_IsBldCrd;
                    result.PermitInfo.Header_IsBldPermit = data.Header.Header_IsBldPermit;
                    result.PermitInfo.Header_NoOfPermit = data.Header.Header_NoOfPermit;
                    result.PermitInfo.Header_RPRNbr = data.Header.Header_RPRNbr;
                    result.PermitInfo.Header_BuildingCardNbr = data.Header.Header_BuildingCardNbr;
                    result.PermitInfo.Header_Grouping = data.Header.Header_Grouping;
                    result.PermitInfo.Header_Origin = data.Header.Header_Origin;
                    result.PermitInfo.Header_Balance = data.Header.Header_FeeAmt;

                    foreach (IXDetail detail in data.Details)
                    {
                        IPermitItem item = new PermitItem();
                        item.Header_ApplicationNbr = data.Header.Header_ApplicationNbr;
                        item.Detail_FeeSort = detail.Detail_FeeSort;
                        item.Detail_Description = detail.Detail_Description;
                        item.Detail_BalanceSheet = detail.Detail_BalanceSheet;
                        item.Detail_Dept = detail.Detail_Dept;
                        item.Detail_Fund = detail.Detail_Fund;
                        item.Detail_RevenueCode = detail.Detail_RevenueCode;
                        item.Detail_SubRevenueCode = detail.Detail_SubRevenueCode;
                        item.Detail_Balance = detail.Detail_FeeAmt;
                        item.Detail_PayAmount = detail.Detail_FeeAmt;
                        result.PermitItems.Add(item);
                    }
                }
                result.WarningMessage = data.ErrorMessage;
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }

            return result;
        }

        public override InquiryResponse3 ParseResult(IInquiryMatch match)
        {
            throw new NotImplementedException();
        }

        public override string UpdatePayment(string deptNo, string appNo, string transNo, string receiptNo, decimal payAmt, DateTime paymentDt)
        {
            throw new NotImplementedException();
        }

        public override string VoidPayment(string receiptNo)
        {
            throw new NotImplementedException();
        }

        private DataContainer GetPermit(string url)
        {
            try
            {
                Task<DataContainer> result = Task.Run(async () => await Util.ApiCall<DataContainer>(url, "", ""));
                result.Wait();
                return result.Result;
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }
        }
    }
}
