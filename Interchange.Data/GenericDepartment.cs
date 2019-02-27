using Interchange.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Interchange.Data
{
    public class GenericDepartment : DataService, IDataService
    {
        public GenericDepartment(string connectionstring, AbstractFacade facade) : base(connectionstring, facade)
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
            IInquiryMatch result = new InquiryMatch();
            try
            {
                dal.SetStoredProc("SIMULATE_PACK.GETTRANSACTION");
                dal.AddParamInString("p_barcodeNbr", transNo);
                dal.AddParamOutRefCursor("p_headerInformation", 1000);
                dal.AddParamOutRefCursor("p_itemInfo", 1000);
                dal.AddParamOutRefCursor("p_detailInformation", 1000);
                dal.AddParamOutString("p_warning", 1000);
                dal.AddParamOutString("p_error", 1000);

                dal.OpenConnection();
                var dataSet = dal.FillDataSet();
                result.WarningMessage = dal.GetParamOutString("p_warning");
                result.ErrorMessage = dal.GetParamOutString("p_error");
                dal.CloseConnection();

                if (!string.IsNullOrEmpty(result.WarningMessage) && result.WarningMessage.ToLower().Equals("ok"))
                {
                    result.WarningMessage = "";
                }

                // Customer Info
                var customerInfo = dataSet.Tables["Table"].AsEnumerable().FirstOrDefault();
                if (customerInfo != null && customerInfo.ItemArray.Length > 1)
                {
                    result.CustomerInfo.Header_CustomerNbr = "";
                    result.CustomerInfo.Header_DeptId = deptNo;
                    result.CustomerInfo.Header_AppId = appNo;
                    result.CustomerInfo.DisplayName = customerInfo["NAME_FULLNAME"].ToString();
                    result.CustomerInfo.DisplayAddress = customerInfo["ADDRESS_JOBADDRESS"].ToString();
                    result.CustomerInfo.Header_ApplicationNbr = customerInfo["HEADER_APPLICATIONNBR"].ToString();

                    // Invoice Info
                    var invoiceList = dataSet.Tables["Table1"].AsEnumerable();
                    foreach (DataRow row in invoiceList)
                    {
                        IInvoiceInformation invoice = new InvoiceInformation();
                        invoice.Header_ApplicationNbr = row["HEADER_APPLICATIONNBR"].ToString();
                        invoice.Header_Balance = decimal.Parse(row["HEADER_BALANCE"].ToString());
                        invoice.Header_AmtDue = decimal.Parse(row["HEADER_BALANCE"].ToString());
                        result.InvoiceList.Add(invoice);
                    }

                    // Line Item Info
                    var lineItemList = dataSet.Tables["Table2"].AsEnumerable();
                    foreach (DataRow row in lineItemList)
                    {
                        IInvoiceItem detail = new InvoiceItem();
                        detail.Header_ApplicationNbr = transNo;
                        detail.Detail_Description = row["DETAIL_DESCRIPTON"].ToString();
                        detail.Detail_PayAmount = decimal.Parse(row["DETAIL_FEEAMT"].ToString());
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
                grpCustInfo.ID = "08003CustomerInformation";
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
                    grpInvoiceInfo.ID = "08003ItemInformation";
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
                    grpLineItems.ID = "08003ItemLineItemInformation";
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
                matchItem.value = pi.GetValue(section, null) != null ? pi.GetValue(section, null).ToString() : "";
                result.MatchItem.Add(matchItem);
            }

            return result;
        }
    }
}
