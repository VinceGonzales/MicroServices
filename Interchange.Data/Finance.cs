using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Interchange.Entity;

namespace Interchange.Data
{
    public class Finance : DataService, IDataService
    {
        public Finance(AbstractFacade facade) : base(facade)
        { }

        public override IInquiryMatch GetByAcctNumber(string deptNo, string appNo, string customerNo)
        {
            IInquiryMatch result = new InquiryMatch();

            try
            {
                dal.SetStoredProc("FSS_POS_PACK.GET_CUSTACCTDETAIL");
                dal.AddParamInString("p_custacctnbr", customerNo);
                dal.AddParamOutRefCursor("p_custinfo", 1000);
                dal.AddParamOutRefCursor("p_invinfo", 1000);
                dal.AddParamOutRefCursor("p_invlineiteminfo", 1000);
                dal.AddParamOutString("p_warning", 1000);

                dal.OpenConnection();
                var dataSet = dal.FillDataSet();
                result.WarningMessage = dal.GetParamOutString("p_warning");
                dal.CloseConnection();

                // Customer Info
                var customerInfo = dataSet.Tables["Table"].AsEnumerable().FirstOrDefault();
                if (customerInfo != null && customerInfo.ItemArray.Length > 1)
                {
                    result.CustomerInfo.Header_CustomerNbr = customerInfo["HEADER_CUSTOMERNBR"].ToString();
                    result.CustomerInfo.Header_DeptId = deptNo;
                    result.CustomerInfo.Header_AppId = appNo;
                    result.CustomerInfo.DisplayName = customerInfo["NAME_FULLNAME"].ToString();
                    result.CustomerInfo.DisplayAddress = customerInfo["ADDRESS_FULLADDRESS"].ToString();

                    // Invoice Info
                    if ((dataSet.Tables["Table1"]).Rows.Count > 0)
                    {
                        var invoiceList = dataSet.Tables["Table1"].AsEnumerable();
                        foreach (DataRow row in invoiceList)
                        {
                            IInvoiceInformation invoice = new InvoiceInformation();
                            invoice.Header_ApplicationNbr = row["HEADER_APPLICATIONNBR"].ToString();
                            invoice.Header_FeeAmt = decimal.Parse(row["HEADER_FEEAMT"].ToString());
                            invoice.Header_AmtPaid = decimal.Parse(row["HEADER_AMTPAID"].ToString());
                            invoice.Header_AmtDue = decimal.Parse(row["HEADER_AMOUNTDUE"].ToString());
                            invoice.Header_Balance = decimal.Parse(row["HEADER_BALANCE"].ToString());
                            result.InvoiceList.Add(invoice);
                        }
                    }

                    // Line Item Info
                    if ((dataSet.Tables["Table2"]).Rows.Count > 0 && (dataSet.Tables["Table2"]).Rows[0].ItemArray.Length > 1)
                    {
                        var lineItemList = dataSet.Tables["Table2"].AsEnumerable();
                        foreach (DataRow row in lineItemList)
                        {
                            IInvoiceItem detail = new InvoiceItem();
                            detail.Header_ApplicationNbr = row["HEADER_APPLICATIONNBR"].ToString();
                            detail.Detail_FeeSort = int.Parse(row["DETAIL_FEESORT"].ToString());
                            detail.Detail_Description = row["DETAIL_DESCRIPTION"].ToString();
                            detail.Detail_FeeAmt = decimal.Parse(row["DETAIL_FEEAMT"].ToString());
                            detail.Detail_AmtPaid = decimal.Parse(row["DETAIL_AMTPAID"].ToString());
                            detail.Detail_Balance = decimal.Parse(row["DETAIL_BALANCE"].ToString());
                            detail.Detail_Dept = row["DETAIL_DEPT"].ToString();
                            detail.Detail_Fund = row["DETAIL_FUND"].ToString();
                            detail.Detail_RevenueCode = row["DETAIL_REVENUECODE"].ToString();
                            detail.Detail_SubRevenueCode = row["DETAIL_SUBREVENUECODE"].ToString();
                            detail.Detail_BalanceSheet = row["DETAIL_BALANCESHEET"].ToString();

                            result.InvoiceItemList.Add(detail);
                        }
                    }

                    result.ResultType = MatchType.SingleEntityMatch;
                }
                else
                {
                    result.CustomerInfo = null;
                    result.InvoiceList = null;
                    result.InvoiceItemList = null;
                    result.MatchList = null;
                    result.ResultType = MatchType.ZeroEntityMatch;
                }
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }

            return result;
        }

        public override IInquiryMatch GetSearchResult(string deptNo, string appNo, string business, string lastname, string firstname)
        {
            IInquiryMatch match = new InquiryMatch();

            try
            {
                dal.SetStoredProc("FSS_POS_PACK.SEARCH_CUSTOMER");
                dal.AddParamInString("p_busname", business);
                dal.AddParamInString("p_lastname", lastname);
                dal.AddParamInString("p_firstname", firstname);
                dal.AddParamInString("p_accountnumber", string.Empty);
                dal.AddParamOutRefCursor("p_result", 1000);

                dal.OpenConnection();
                var dataSet = dal.FillDataSet();
                dal.CloseConnection();

                var result = dataSet.Tables[0].AsEnumerable().ToList();

                if (result.Count == 1)
                {
                    string customerNo = result[0]["HEADER_CUSTOMERNBR"].ToString();
                    match = GetByAcctNumber(deptNo, appNo, customerNo);
                }
                else if (result.Count > 1)
                {
                    foreach (DataRow row in result)
                    {
                        IMatchInfo customer = new MatchInfo();
                        customer.Header_DeptId = deptNo;
                        customer.Header_AppId = appNo;
                        customer.Header_CustomerNbr = row["HEADER_CUSTOMERNBR"].ToString();
                        customer.DisplayName = row["NAME_BUSINESSNAME"].ToString();
                        customer.Name_LName = row["NAME_LNAME"].ToString();
                        customer.Name_FName = row["NAME_FNAME"].ToString();
                        customer.DisplayAddress = row["ADDRESS"].ToString();
                        match.MatchList.Add(customer);
                    }
                    match.ResultType = MatchType.MultiEntityMatch;
                }
                else
                {
                    match.CustomerInfo = null;
                    match.InvoiceList = null;
                    match.InvoiceItemList = null;
                    match.MatchList = null;
                    match.ResultType = MatchType.ZeroEntityMatch;
                }
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }

            return match;
        }

        public override IInquiryMatch GetTransaction(string deptNo, string appNo, string transNo)
        {
            IInquiryMatch result = new InquiryMatch();
            try
            {
                dal.SetStoredProc("FSS_POS_PACK.GET_TRANSACTION");
                dal.AddParamInString("p_deptNo", deptNo);
                dal.AddParamInString("p_appNo", appNo);
                dal.AddParamInString("p_transNo", transNo);
                dal.AddParamOutRefCursor("p_custinfo", 1000);
                dal.AddParamOutRefCursor("p_transinfo", 1000);
                dal.AddParamOutRefCursor("p_translineiteminfo", 1000);
                dal.AddParamOutString("p_warning", 1000);

                dal.OpenConnection();
                var dataSet = dal.FillDataSet();
                result.WarningMessage = dal.GetParamOutString("p_warning");
                dal.CloseConnection();

                // Customer Info
                var customerInfo = dataSet.Tables["Table"].AsEnumerable().FirstOrDefault();
                if (customerInfo != null && customerInfo.ItemArray.Length > 1)
                {
                    result.CustomerInfo.Header_CustomerNbr = customerInfo["HEADER_CUSTOMERNBR"].ToString();
                    result.CustomerInfo.Header_DeptId = deptNo;
                    result.CustomerInfo.Header_AppId = appNo;
                    result.CustomerInfo.DisplayName = customerInfo["NAME_FULLNAME"].ToString();
                    result.CustomerInfo.DisplayAddress = customerInfo["ADDRESS_FULLADDRESS"].ToString();
                    result.CustomerInfo.Header_ApplicationNbr = transNo;

                    // Invoice Info
                    var invoiceList = dataSet.Tables["Table1"].AsEnumerable();
                    foreach (DataRow row in invoiceList)
                    {
                        IInvoiceInformation invoice = new InvoiceInformation();
                        invoice.Header_ApplicationNbr = row["HEADER_APPLICATIONNBR"].ToString();
                        invoice.Header_FeeAmt = decimal.Parse(row["HEADER_FEEAMT"].ToString());
                        invoice.Header_AmtPaid = decimal.Parse(row["HEADER_AMTPAID"].ToString());
                        invoice.Header_AmtDue = decimal.Parse(row["HEADER_AMOUNTDUE"].ToString());
                        invoice.Header_Balance = decimal.Parse(row["HEADER_BALANCE"].ToString());
                        result.InvoiceList.Add(invoice);
                    }

                    // Line Item Info
                    var lineItemList = dataSet.Tables["Table2"].AsEnumerable();
                    foreach (DataRow row in lineItemList)
                    {
                        IInvoiceItem detail = new InvoiceItem();
                        detail.Header_ApplicationNbr = row["HEADER_APPLICATIONNBR"].ToString();
                        detail.Detail_FeeSort = int.Parse(row["DETAIL_FEESORT"].ToString());
                        detail.Detail_Description = row["DETAIL_DESCRIPTION"].ToString();
                        detail.Detail_FeeAmt = decimal.Parse(row["DETAIL_FEEAMT"].ToString());
                        detail.Detail_AmtPaid = decimal.Parse(row["DETAIL_AMTPAID"].ToString());
                        detail.Detail_Balance = decimal.Parse(row["DETAIL_BALANCE"].ToString());
                        detail.Detail_Dept = row["DETAIL_DEPT"].ToString();
                        detail.Detail_Fund = row["DETAIL_FUND"].ToString();
                        detail.Detail_RevenueCode = row["DETAIL_REVENUECODE"].ToString();
                        detail.Detail_SubRevenueCode = row["DETAIL_SUBREVENUECODE"].ToString();
                        detail.Detail_BalanceSheet = row["DETAIL_BALANCESHEET"].ToString();

                        result.InvoiceItemList.Add(detail);
                    }

                    result.ResultType = MatchType.SingleEntityMatch;
                }
                else
                {
                    result.CustomerInfo = null;
                    result.InvoiceList = null;
                    result.InvoiceItemList = null;
                    result.MatchList = null;
                    result.ResultType = MatchType.ZeroEntityMatch;
                }
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
            InquiryResponse3 resp = new InquiryResponse3();

            if (match.ResultType == MatchType.SingleEntityMatch)
            {
                resp.Type = match.ResultType.ToString();

                resp.DetailData = new DetailData();
                resp.DetailData.Group = new List<Group>();

                Group grpCustInfo = new Group();
                grpCustInfo.count = 1;
                grpCustInfo.ID = "08002CustomerInformation";
                grpCustInfo.DetailLine = new List<DetailLine>();
                grpCustInfo.DetailLine.Add(GetDetail(match.CustomerInfo));
                resp.DetailData.Group.Add(grpCustInfo);

                if (!string.IsNullOrEmpty(match.WarningMessage) && !match.WarningMessage.Equals("null") && !match.WarningMessage.ToLower().Equals("ok"))
                {
                    Group grpWarning = new Group();
                    grpWarning.count = 1;
                    grpWarning.ID = "Warning";
                    grpWarning.DetailLine = new List<DetailLine>();
                    DetailLine detailline = new DetailLine();
                    detailline.DetailLineItem = new List<DetailLineItem>();
                    detailline.DetailLineItem.Add(new DetailLineItem("Header_Warning", match.WarningMessage));
                    grpWarning.DetailLine.Add(detailline);
                    resp.DetailData.Group.Add(grpWarning);
                }

                if (match.InvoiceList.Count > 0)
                {
                    Group grpInvoiceInfo = new Group();
                    grpInvoiceInfo.count = match.InvoiceList.Count;
                    grpInvoiceInfo.ID = "08002InvoiceInformation";
                    grpInvoiceInfo.DetailLine = new List<DetailLine>();
                    foreach (InvoiceInformation invoice in match.InvoiceList)
                    {
                        grpInvoiceInfo.DetailLine.Add(GetDetail(invoice));
                    }
                    resp.DetailData.Group.Add(grpInvoiceInfo);
                }

                if (match.InvoiceItemList.Count > 0)
                {
                    Group grpLineItems = new Group();
                    grpLineItems.count = match.InvoiceItemList.Count;
                    grpLineItems.ID = "08002InvoiceLineItemInformation";
                    grpLineItems.DetailLine = new List<DetailLine>();
                    foreach (IInvoiceItem detail in match.InvoiceItemList)
                    {
                        grpLineItems.DetailLine.Add(GetDetail(detail));
                    }
                    resp.DetailData.Group.Add(grpLineItems);
                }
            }
            else if (match.ResultType == MatchType.MultiEntityMatch)
            {
                resp.Type = match.ResultType.ToString();
                resp.Matches = new Matches();
                resp.Matches.Count = match.MatchList.Count.ToString();
                resp.Matches.Match = new List<Match>();
                foreach (IMatchInfo cust in match.MatchList)
                {
                    resp.Matches.Match.Add(GetMatch(cust));
                }
            }
            else if (match.ResultType == MatchType.ZeroEntityMatch)
            {
                resp.Type = match.ResultType.ToString();
                resp.ErrorCode = "404";
                resp.ErrorSummary = match.WarningMessage;
                resp.ErrorDetail = match.WarningMessage;
            }

            return resp;
        }

        public override string UpdatePayment(string deptNo, string appNo, string transNo, string receiptNo, decimal payAmt, DateTime paymentDt)
        {
            throw new NotImplementedException();
        }

        public override string VoidPayment(string receiptNo)
        {
            throw new NotImplementedException();
        }

        private Match GetMatch(dynamic section)
        {
            Match result = new Match();
            result.MatchItem = new List<MatchItem>();

            foreach (PropertyInfo pi in section.GetType().GetProperties())
            {
                MatchItem matchItem = new MatchItem();
                matchItem.name = pi.Name;
                matchItem.value = pi.GetValue(section, null).ToString();
                result.MatchItem.Add(matchItem);
            }

            return result;
        }
    }
}
