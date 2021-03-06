﻿using Interchange.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Interchange.Data
{
    public class Permit : DataService, IDataService
    {
        public Permit(string connectionstring, AbstractFacade facade) : base(connectionstring, facade)
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
                dal.SetStoredProc("PCIS_POS_PACK.GETTRANSACTION");
                dal.AddParamInString("p_deptNo", deptNo);
                dal.AddParamInString("p_appNo", appNo);
                dal.AddParamInString("p_transNo", transNo);
                dal.AddParamOutRefCursor("p_permitInformation", 1000);
                dal.AddParamOutRefCursor("p_PermitLineItemInformation", 1000);
                dal.AddParamOutRefCursor("p_bondInformation", 1000);
                dal.AddParamOutRefCursor("p_BondLineItemInformation", 1000);
                dal.AddParamOutString("p_warning", 1000);
                dal.AddParamOutString("p_error", 1000);

                dal.OpenConnection();
                var dataSet = dal.FillDataSet();
                result.WarningMessage = dal.CMD.Parameters["p_warning"].Value.ToString();
                result.ErrorMessage = dal.CMD.Parameters["p_error"].Value.ToString();
                dal.CloseConnection();

                if (!string.IsNullOrEmpty(result.WarningMessage) && !result.WarningMessage.ToLower().Equals("ok"))
                {
                    result.WarningMessage = "";
                }

                if (string.IsNullOrEmpty(result.ErrorMessage) || result.ErrorMessage.Equals("OK"))
                {
                    var headerInfo = dataSet.Tables["Table"].AsEnumerable().FirstOrDefault();
                    result.PermitInfo.Header_DeptId = deptNo;
                    result.PermitInfo.Header_AppId = appNo;
                    result.PermitInfo.DisplayName = headerInfo["NAME_FULLNAME"].ToString();
                    result.PermitInfo.DisplayAddress = headerInfo["ADDRESS_JOBADDRESS"].ToString();
                    result.PermitInfo.Header_ApplicationNbr = headerInfo["HEADER_APPLICATIONNBR"].ToString();
                    result.PermitInfo.Header_Barcode = headerInfo["HEADER_BARCODE"].ToString();
                    result.PermitInfo.Header_IsBldCrd = headerInfo["HEADER_ISBLDCRD"].ToString() == "F" ? false : true;
                    result.PermitInfo.Header_IsBldPermit = headerInfo["HEADER_ISBLDPERMIT"].ToString() == "F" ? false : true;
                    result.PermitInfo.Header_NoOfPermit = int.Parse(headerInfo["HEADER_NOOFPERMITS"].ToString());
                    result.PermitInfo.Header_RPRNbr = int.Parse(headerInfo["HEADER_RPRNBR"].ToString());
                    result.PermitInfo.Header_BuildingCardNbr = headerInfo["HEADER_BUILDINGCARDNBR"].ToString();
                    result.PermitInfo.Header_Grouping = headerInfo["HEADER_GROUPING"].ToString();
                    result.PermitInfo.Header_CustomerNbr = headerInfo["HEADER_CUSTOMERNBR"].ToString();
                    result.PermitInfo.Header_Origin = headerInfo["HEADER_ORIGIN"].ToString();
                    result.PermitInfo.Header_FeeAmt = decimal.Parse(headerInfo["HEADER_BALANCE"].ToString());

                    var detailList = dataSet.Tables["Table1"].AsEnumerable();
                    foreach (DataRow row in detailList)
                    {
                        IInvoiceItem item = new InvoiceItem();
                        item.Header_ApplicationNbr = headerInfo["HEADER_APPLICATIONNBR"].ToString();
                        item.Detail_FeeSort = int.Parse(row["DETAIL_FEESORT"].ToString());
                        item.Detail_Description = row["DETAIL_DESCRIPTION"].ToString();
                        item.Detail_FeeAmt = decimal.Parse(row["DETAIL_BALANCE"].ToString());
                        item.Detail_AmtPaid = 0M;
                        item.Detail_Balance = decimal.Parse(row["DETAIL_BALANCE"].ToString());
                        item.Detail_PayAmount = decimal.Parse(row["DETAIL_BALANCE"].ToString());
                        item.Detail_Dept = row["DETAIL_DEPT"].ToString();
                        item.Detail_Fund = row["DETAIL_FUND"].ToString();
                        item.Detail_RevenueCode = row["DETAIL_REVENUECODE"].ToString();
                        item.Detail_SubRevenueCode = row["DETAIL_SUBREVENUECODE"].ToString();
                        item.Detail_BalanceSheet = row["DETAIL_BALANCESHEET"].ToString();
                        result.PermitItems.Add(item);
                    }

                    var info = dataSet.Tables["Table2"].AsEnumerable().FirstOrDefault();
                    IInvoiceInformation bondInfo = new InvoiceInformation();
                    bondInfo.Header_ApplicationNbr = info["HEADER_APPLICATIONNBR"].ToString();
                    bondInfo.Header_Balance = decimal.Parse(info["DETAIL_BALANCE"].ToString());
                    result.InvoiceList.Add(bondInfo);

                    var bondItemList = dataSet.Tables["Table3"].AsEnumerable();
                    foreach (DataRow row in bondItemList)
                    {
                        IInvoiceItem bondItem = new InvoiceItem();
                        bondItem.Header_ApplicationNbr = row["HEADER_APPLICATIONNBR"].ToString();
                        bondItem.Detail_FeeSort = int.Parse(row["DETAIL_FEESORT"].ToString());
                        bondItem.Detail_Description = row["DETAIL_DESCRIPTION"].ToString();
                        bondItem.Detail_FeeAmt = decimal.Parse(row["DETAIL_FEEAMT"].ToString());
                        bondItem.Detail_AmtPaid = decimal.Parse(row["DETAIL_AMTPAID"].ToString());
                        bondItem.Detail_Balance = decimal.Parse(row["DETAIL_BALANCE"].ToString());
                        result.InvoiceItemList.Add(bondItem);
                    }
                    result.ErrorMessage = "";
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
            IPermitMatch details = (PermitMatch)match;

            if (string.IsNullOrEmpty(details.ErrorMessage))
            {
                resp.Type = MatchType.SingleEntityMatch.ToString();
                resp.DetailData = new DetailData();
                resp.DetailData.Group = new List<Group>();

                Group grpPermitInfo = new Group();
                grpPermitInfo.count = 1;
                grpPermitInfo.ID = "08001PermitInformation";
                grpPermitInfo.DetailLine = new List<DetailLine>();
                grpPermitInfo.DetailLine.Add(GetDetail(details.PermitInfo));
                resp.DetailData.Group.Add(grpPermitInfo);

                if (!string.IsNullOrEmpty(details.WarningMessage) && !details.WarningMessage.Equals("null") && !details.WarningMessage.ToLower().Equals("ok"))
                {
                    Group grpWarning = new Group();
                    grpWarning.count = 1;
                    grpWarning.ID = "Warning";
                    grpWarning.DetailLine = new List<DetailLine>();
                    DetailLine detailline = new DetailLine();
                    detailline.DetailLineItem = new List<DetailLineItem>();
                    detailline.DetailLineItem.Add(new DetailLineItem("Header_Warning", details.WarningMessage));
                    grpWarning.DetailLine.Add(detailline);
                    resp.DetailData.Group.Add(grpWarning);
                }

                Group grpPermitItem = new Group();
                grpPermitItem.count = details.PermitItems.Count;
                grpPermitItem.ID = "08001PermitLineItemInformation";
                grpPermitItem.DetailLine = new List<DetailLine>();
                foreach (IInvoiceItem detail in details.PermitItems)
                {
                    grpPermitItem.DetailLine.Add(GetDetail(detail));
                }
                resp.DetailData.Group.Add(grpPermitItem);

                if (details.InvoiceList != null && details.InvoiceList.Count > 0)
                {
                    Group grpBondInformation = new Group();
                    grpBondInformation.count = 1;
                    grpBondInformation.ID = "08001BondInformation";
                    grpBondInformation.DetailLine = new List<DetailLine>();
                    foreach (IInvoiceInformation info in details.InvoiceList)
                    {
                        grpBondInformation.DetailLine.Add(GetDetail(info));
                    }
                    resp.DetailData.Group.Add(grpBondInformation);

                    Group grpBondLineItemInformation = new Group();
                    grpBondLineItemInformation.count = details.InvoiceItemList.Count;
                    grpBondLineItemInformation.ID = "08001BondLineItemInformation";
                    grpBondLineItemInformation.DetailLine = new List<DetailLine>();
                    foreach (IInvoiceItem item in details.InvoiceItemList)
                    {
                        grpBondLineItemInformation.DetailLine.Add(GetDetail(item));
                    }
                    resp.DetailData.Group.Add(grpBondLineItemInformation);
                }
            }
            else
            {
                resp.Type = MatchType.ZeroEntityMatch.ToString();
                resp.ErrorCode = "404";
                resp.ErrorSummary = details.ErrorMessage;
                resp.ErrorDetail = details.ErrorMessage;
            }
            return resp;
        }

        public override string UpdatePayment(string deptNo, string appNo, string transNo, string receiptNo, decimal payAmt, DateTime paymentDt)
        {
            string result = "";
            try
            {
                dal.SetStoredProc("PCIS_POS_PACK.UPDATEPERMITPAYMENT");
                dal.AddParamInString("p_transNo", transNo);
                dal.AddParamInDecimal("p_pmtTotAmt", payAmt);
                dal.AddParamInString("p_receiptNbr", receiptNo);
                dal.AddParamOutString("p_warning", 1000);

                dal.OpenConnection();
                dal.Execute();
                result = dal.GetParamOutString("p_warning");
                dal.CloseConnection();

                result = receiptNo;
            }
            catch (Exception exc)
            {
                exc.HelpLink = "";
                throw exc;
            }

            return result;
        }

        public override string VoidPayment(string receiptNo)
        {
            throw new NotImplementedException();
        }
    }
}
