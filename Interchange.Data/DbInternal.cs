using Interchange.Entity;
using System;
using System.Configuration;

namespace Interchange.Data
{
    public class DbInternal : IDbInternal
    {
        private AbstractFacade dal;

        public DbInternal(AbstractFacade facade, string connectionstring)
        {
            dal = facade;
            dal.ConnectionString = ConfigurationManager.AppSettings[connectionstring];
        }

        public int InsertTransaction(IXHeader header)
        {
            int result = 0;
            try
            {
                dal.SetStoredProc("XCHANGE_PACK.INSERTTRANSACTION");
                dal.AddParamInString("p_deptId", header.Header_DeptId);
                dal.AddParamInString("p_appId", header.Header_AppId);
                dal.AddParamInString("p_applicationNbr", header.Header_ApplicationNbr);
                dal.AddParamInString("p_barcode", header.Header_Barcode);
                dal.AddParamInString("p_isBldCrd", header.Header_IsBldCrd ? "T" : "F");
                dal.AddParamInString("p_isBldPermit", header.Header_IsBldPermit ? "T" : "F");
                dal.AddParamInInt32("p_noOfPermit", header.Header_NoOfPermit);
                dal.AddParamInString("p_receiptRefNbr", header.Header_ReceiptRefNbr);
                dal.AddParamInInt32("p_RPRNbr", header.Header_RPRNbr);
                dal.AddParamInString("p_buildingCardNbr", header.Header_BuildingCardNbr);
                dal.AddParamInString("p_grouping", header.Header_Grouping);
                dal.AddParamInString("p_customerNbr", header.Header_CustomerNbr);
                dal.AddParamInString("p_origin", header.Header_Origin);
                dal.AddParamInString("p_feeAmount", header.Header_FeeAmt.ToString());
                if (header.Header_PaymentDate.HasValue)
                {
                    dal.AddParamInDate("p_paymentDate", header.Header_PaymentDate.Value);
                }
                else
                {
                    dal.AddParamInDateNullable("p_paymentDate", null);
                }
                dal.AddParamOutInt32("p_interchangeID", 1000);

                dal.OpenConnection();
                dal.Execute();
                result = dal.GetParamOutInt32("p_interchangeID");
                dal.CloseConnection();
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }
            return result;
        }

        public string InsertAddress(IXAddress address, int interchangeId)
        {
            try
            {
                dal.SetStoredProc("XCHANGE_PACK.INSERTADDRESS");
                dal.AddParamInInt32("p_interchangeId", interchangeId);
                dal.AddParamInString("p_addressType", address.Address_AddressType);
                dal.AddParamInString("p_nbrRangeStart", address.Address_NbrRangeStart);
                dal.AddParamInString("p_nbrRangeEnd", address.Address_NbrRangeEnd);
                dal.AddParamInString("p_FracRangeStart", address.Address_FracRangeStart);
                dal.AddParamInString("p_FracRangeEnd", address.Address_FracRangeEnd);
                dal.AddParamInString("p_unitRangeStart", address.Address_UnitRangeStart);
                dal.AddParamInString("p_unitRangeEnd", address.Address_UnitRangeEnd);
                dal.AddParamInString("p_strDir", address.Address_StrDir);
                dal.AddParamInString("p_strName", address.Address_StrName);
                dal.AddParamInString("p_strSuff", address.Address_StrSuff);
                dal.AddParamInString("p_strSuffDir", address.Address_StrSuffDir);
                dal.AddParamInString("p_cityName", address.Address_CityName);
                dal.AddParamInString("p_stateCode", address.Address_StateCode);
                dal.AddParamInString("p_zipCode", address.Address_Zipcode);

                dal.OpenConnection();
                dal.Execute();
                dal.CloseConnection();

                return ResponseType.Success.ToString();
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }
        }

        public string InsertDetail(IXDetail detail, int interchangeId)
        {
            try
            {
                dal.SetStoredProc("XCHANGE_PACK.INSERTDETAILS");
                dal.AddParamInInt32("p_interchangeId", interchangeId);
                dal.AddParamInString("p_feeType", detail.Detail_FeeType);
                dal.AddParamInString("p_feeCode", detail.Detail_FeeCod);
                dal.AddParamInString("p_feePeriod", detail.Detail_FeePeriod);
                dal.AddParamInString("p_feeCategory", detail.Detail_FeeCat);
                dal.AddParamInString("p_dept", detail.Detail_Dept);
                dal.AddParamInString("p_fund", detail.Detail_Fund);
                dal.AddParamInString("p_revenueCode", detail.Detail_RevenueCode);
                dal.AddParamInString("p_subRevenueCode", detail.Detail_SubRevenueCode);
                dal.AddParamInString("p_balanceSheet", detail.Detail_BalanceSheet);
                dal.AddParamInString("p_description", detail.Detail_Description);
                dal.AddParamInString("p_feeSort", detail.Detail_FeeSort.ToString());
                dal.AddParamInDecimal("p_feeAmount", detail.Detail_FeeAmt);

                dal.OpenConnection();
                dal.Execute();
                dal.CloseConnection();

                return ResponseType.Success.ToString();
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }
        }

        public string InsertName(IXName name, int interchangeId)
        {
            try
            {
                dal.SetStoredProc("XCHANGE_PACK.INSERTNAME");
                dal.AddParamInInt32("p_interchangeId", interchangeId);
                dal.AddParamInString("p_relationship", name.Name_Relationship);
                dal.AddParamInString("p_fname", name.Name_FName);
                dal.AddParamInString("p_mname", name.Name_MName);
                dal.AddParamInString("p_lname", name.Name_LName);
                dal.AddParamInString("p_email", name.Name_Email);
                dal.AddParamInString("p_businessName", name.BusinessName);

                dal.OpenConnection();
                dal.Execute();
                dal.CloseConnection();

                return ResponseType.Success.ToString();
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }
        }

        public TransactionPayment GetPayment(int interchangeId)
        {
            TransactionPayment result = new TransactionPayment();
            try
            {
                dal.SetStoredProc("XCHANGE_PACK.GETPAYMENT");
                dal.AddParamInInt32("p_interchangeId", interchangeId);
                dal.AddParamOutString("p_receiptNbr", 1000);
                dal.AddParamOutDate("p_paymentDate");
                dal.AddParamOutString("p_warning", 1000);

                dal.OpenConnection();
                dal.Execute();
                result.InterchangeId = interchangeId;
                result.ReceiptNbr = dal.GetParamOutString("p_receiptNbr");
                DateTime datetime = DateTime.Parse(dal.GetParamOutString("p_paymentDate"));
                if (datetime != null)
                {
                    result.PaymentDate = DateTime.Parse(dal.GetParamOutString("p_paymentDate")).ToString("{0:G}");
                }
                result.Message = dal.GetParamOutString("p_warning");
                dal.CloseConnection();
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }
            return result;
        }

        public string DeleteRecord(int interchangeId)
        {
            try
            {
                dal.SetStoredProc("XCHANGE_PACK.DELETETRANSACTION");
                dal.AddParamInInt32("p_interchangeId", interchangeId);

                dal.OpenConnection();
                dal.Execute();
                dal.CloseConnection();

                return ResponseType.Success.ToString();
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }
        }
    }
    public interface IDbInternal
    {
        int InsertTransaction(IXHeader header);
        string InsertDetail(IXDetail detail, int interchangeId);
        string InsertName(IXName name, int interchangeId);
        string InsertAddress(IXAddress address, int interchangeId);
        string DeleteRecord(int interchangeId);
        TransactionPayment GetPayment(int interchangeId);
    }
}
