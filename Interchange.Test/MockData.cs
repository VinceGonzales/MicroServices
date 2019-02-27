using FakeModel;
using Interchange.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace Interchange.Test
{
    public class MockData
    {
        public static InquiryRequest CreateInquiryRequest(string sysInterfaceId, QueryKey qrykey)
        {
            InquiryRequest result = new InquiryRequest();
            result.WorkgroupID = "test";
            result.UserID = "test";
            result.BannerID = "test";
            result.TransType = "test";
            result.CoreFileEffDT = "test";
            result.QuerySourcePage = "test";

            SystemInterface si = new SystemInterface();
            si.Description = "test";
            si.ID = sysInterfaceId;
            si.Type = "test";
            si.DatasourceName = "DEV";
            si.DatabaseName = "test";
            si.LoginName = "test";
            si.LoginPassword = "test";
            si.InterfaceDefinition = "test";
            si.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "test", value = "test" } };
            result.SystemInterfaces = new SystemInterfaces { SystemInterface = new SystemInterface[] { si } };

            QueryKey deptNo = new QueryKey { name = "Header_DeptId", value = "08" };
            QueryKey appNo = new QueryKey { name = "Header_AppId", value = "002" };
            result.QueryKeys = new QueryKeys { QueryKey = new QueryKey[] { deptNo, appNo, qrykey } };

            return result;
        }

        public static InquiryRequest CreateSearchInquiryRequest()
        {
            InquiryRequest result = new InquiryRequest();
            result.WorkgroupID = "test";
            result.UserID = "test";
            result.BannerID = "test";
            result.TransType = "test";
            result.CoreFileEffDT = "test";
            result.QuerySourcePage = "test";

            SystemInterface si = new SystemInterface();
            si.Description = "test";
            si.ID = "InterchangeUpdate";
            si.Type = "test";
            si.DatasourceName = "DEV";
            si.DatabaseName = "test";
            si.LoginName = "test";
            si.LoginPassword = "test";
            si.InterfaceDefinition = "test";
            si.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "test", value = "test" } };
            result.SystemInterfaces = new SystemInterfaces { SystemInterface = new SystemInterface[] { si } };

            QueryKey deptNo = new QueryKey { name = "Header_DeptId", value = "08" };
            QueryKey appNo = new QueryKey { name = "Header_AppId", value = "002" };

            QueryKey businessName = new QueryKey { name = "Name_Businessname", value = "test" };
            QueryKey lastName = new QueryKey { name = "Name_LName", value = "test" };
            QueryKey firstName = new QueryKey { name = "Name_FName", value = "test" };

            result.QueryKeys = new QueryKeys { QueryKey = new QueryKey[] { deptNo, appNo, businessName, lastName, firstName } };

            return result;
        }

        public static InquiryRequest CreateInqReq4Permit(string sysInterfaceId, QueryKey qrykey)
        {
            InquiryRequest result = new InquiryRequest();
            result.WorkgroupID = "test";
            result.UserID = "test";
            result.BannerID = "test";
            result.TransType = "test";
            result.CoreFileEffDT = "test";
            result.QuerySourcePage = "test";

            SystemInterface si = new SystemInterface();
            si.Description = "test";
            si.ID = sysInterfaceId;
            si.Type = "test";
            si.DatasourceName = "DEV";
            si.DatabaseName = "test";
            si.LoginName = "test";
            si.LoginPassword = "test";
            si.InterfaceDefinition = "test";
            si.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "test", value = "test" } };
            result.SystemInterfaces = new SystemInterfaces { SystemInterface = new SystemInterface[] { si } };

            QueryKey deptNo = new QueryKey { name = "Header_DeptId", value = "08" };
            QueryKey appNo = new QueryKey { name = "Header_AppId", value = "001" };
            result.QueryKeys = new QueryKeys { QueryKey = new QueryKey[] { deptNo, appNo, qrykey } };

            return result;
        }

        public static InquiryResponse3 CreateInquiryResponse3()
        {
            InquiryResponse3 result = new InquiryResponse3();
            result.Type = MatchType.SingleEntityMatch.ToString();
            result.ErrorCode = "test";
            result.ErrorSummary = "test";
            result.ErrorDetail = "test";

            GeneralLineItem gli = new GeneralLineItem { name = "test", value = "test" };
            result.GeneralData = new GeneralData { GeneralLineItem = new GeneralLineItem[] { gli } };

            MatchItem mi = new MatchItem("test", "test");
            Entity.Match m = new Entity.Match();
            m.MatchItem = new List<MatchItem>();
            m.MatchItem.Add(mi);
            Matches ms = new Matches();
            ms.Count = "test";
            ms.Match = new List<Entity.Match>();
            ms.Match.Add(m);
            result.Matches = ms;

            DetailLine dl = new DetailLine();
            dl.DetailLineItem = new List<DetailLineItem>();
            dl.DetailLineItem.Add(new DetailLineItem("test", "test"));
            Group g = new Group();
            g.ID = "test";
            g.BankRuleID = "test";
            g.count = 1;
            g.DetailLine = new List<DetailLine>();
            g.DetailLine.Add(dl);
            DetailData dd = new DetailData();
            dd.Group = new List<Group>();
            dd.Group.Add(g);
            result.DetailData = dd;

            return result;
        }

        public static UpdateRequest CreateMultiInvoiceUpdateRequest(string sysInterfaceId)
        {
            UpdateRequest result = new UpdateRequest();
            result.Type = "test";

            SystemInterface si = new SystemInterface();
            si.Description = "test";
            si.ID = sysInterfaceId;
            si.Type = "test";
            si.DatasourceName = "test";
            si.DatabaseName = "test";
            si.LoginName = "test";
            si.LoginPassword = "test";
            si.InterfaceDefinition = "test";
            si.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "test", value = "test" } };
            result.SystemInterfaces = new SystemInterfaces { SystemInterface = new SystemInterface[] { si } };

            COREEvent ce = new COREEvent();
            ce.ReceiptReferenceNbr = "1234567890R";
            ce.COREEventItem = new COREEventItem[] { new COREEventItem { name = "CREATION_DT", value = "01/10/2019 13:11:26" } };
            ce.TTAMAPPING = new TTA[] { new TTA { TRANNBR = "2", TNDRNBR = "1", AMOUNT = "1.25" }, new TTA { TRANNBR = "4", TNDRNBR = "1", AMOUNT = "2.75" } };
            Transaction t1 = new Transaction();
            TransactionItem deptNo = new TransactionItem { name = "Header_DeptId", value = "08" };
            TransactionItem appNo = new TransactionItem { name = "Header_AppId", value = "002" };
            TransactionItem transNo1 = new TransactionItem { name = "Header_ApplicationNbr", value = "123456" };
            TransactionItem trNo1 = new TransactionItem { name = "TRANNBR", value = "2" };
            TransactionItem receiptNo1 = new TransactionItem { name = "transactionreferencenbr", value = "9999999999-5-1" };
            t1.TransactionItem = new TransactionItem[] { deptNo, appNo, transNo1, trNo1, receiptNo1 };
            Transaction t2 = new Transaction();
            TransactionItem transNo2 = new TransactionItem { name = "Header_ApplicationNbr", value = "678901" };
            TransactionItem trNo2 = new TransactionItem { name = "TRANNBR", value = "4" };
            TransactionItem receiptNo2 = new TransactionItem { name = "transactionreferencenbr", value = "9999999999-5-2" };
            t2.TransactionItem = new TransactionItem[] { deptNo, appNo, transNo2, trNo2, receiptNo2 };
            Transactions ts = new Transactions();
            ts.Count = "2";
            ts.Transaction = new Transaction[] { t1, t2 };
            ce.Transactions = new Transactions[] { ts };
            Tender ten = new Tender();
            ten.TenderItem = new TenderItem[] { new TenderItem { name = "TNDRNBR", value = "1" }, new TenderItem { name = "total", value = "4.00" } };
            Tenders tens = new Tenders();
            tens.Count = "1";
            tens.Tender = new Tender[] { ten };
            ce.Tenders = new Tenders[] { tens };

            COREFile cf = new COREFile();
            cf.POSTDT = "test";
            cf.COREFileItem = new COREFileItem[] { new COREFileItem { name = "test", value = "test" } };
            COREEvents ces = new COREEvents();
            ces.COREEvent = new COREEvent[] { ce };
            cf.COREEvents = new COREEvents[] { ces };
            result.COREFile = new COREFile[] { cf };

            return result;
        }

        public static UpdateRequest CreateSingleInvoiceUpdateRequest(string sysInterfaceId)
        {
            UpdateRequest result = new UpdateRequest();
            result.Type = "test";

            SystemInterface si = new SystemInterface();
            si.Description = "test";
            si.ID = sysInterfaceId;
            si.Type = "test";
            si.DatasourceName = "test";
            si.DatabaseName = "test";
            si.LoginName = "test";
            si.LoginPassword = "test";
            si.InterfaceDefinition = "test";
            si.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "test", value = "test" } };
            result.SystemInterfaces = new SystemInterfaces { SystemInterface = new SystemInterface[] { si } };

            COREEvent ce = new COREEvent();
            ce.ReceiptReferenceNbr = "1234567890R";
            ce.COREEventItem = new COREEventItem[] { new COREEventItem { name = "CREATION_DT", value = "01/10/2019 13:11:26" } };
            ce.TTAMAPPING = new TTA[] { new TTA { TRANNBR = "2", TNDRNBR = "1", AMOUNT = "2.25" } };
            Transaction t1 = new Transaction();
            TransactionItem deptNo = new TransactionItem { name = "Header_DeptId", value = "08" };
            TransactionItem appNo = new TransactionItem { name = "Header_AppId", value = "002" };
            TransactionItem transNo1 = new TransactionItem { name = "Header_ApplicationNbr", value = "123456" };
            TransactionItem trNo1 = new TransactionItem { name = "TRANNBR", value = "2" };
            TransactionItem receiptNo1 = new TransactionItem { name = "transactionreferencenbr", value = "9999999999-5-1" };
            t1.TransactionItem = new TransactionItem[] { deptNo, appNo, transNo1, trNo1, receiptNo1 };
            Transactions ts = new Transactions();
            ts.Count = "2";
            ts.Transaction = new Transaction[] { t1 };
            ce.Transactions = new Transactions[] { ts };
            Tender ten = new Tender();
            ten.TenderItem = new TenderItem[] { new TenderItem { name = "TNDRNBR", value = "1" }, new TenderItem { name = "total", value = "2.25" } };
            Tenders tens = new Tenders();
            tens.Count = "1";
            tens.Tender = new Tender[] { ten };
            ce.Tenders = new Tenders[] { tens };

            COREFile cf = new COREFile();
            cf.POSTDT = "test";
            cf.COREFileItem = new COREFileItem[] { new COREFileItem { name = "test", value = "test" } };
            COREEvents ces = new COREEvents();
            ces.COREEvent = new COREEvent[] { ce };
            cf.COREEvents = new COREEvents[] { ces };
            result.COREFile = new COREFile[] { cf };

            return result;
        }

        public static UpdateResponse CreateUpdateResponseSuccess(string receiptNo)
        {
            UpdateResponse response = new UpdateResponse();
            response.Type = Interchange.Data.ResponseType.Success.ToString();
            response.UpdateReference = receiptNo;
            return response;
        }

        public static VoidRequest CreateVoidRequest()
        {
            VoidRequest request = new VoidRequest();
            request.Type = "Real Time Void";
            request.UpdateReference = "1234567890-1";
            request.SystemInterfaces = new SystemInterfaces();
            SystemInterface sysinterface = new SystemInterface();
            sysinterface.Description = "LADBS Invoice Update";
            sysinterface.ID = "InterchangeUpdate";
            sysinterface.Type = "Web Service";
            sysinterface.DatasourceName = "DEV";
            sysinterface.DatabaseName = "DOESNOTMATTER";
            sysinterface.LoginName = "DOESNOTMATTER";
            sysinterface.LoginPassword = "cashier";
            sysinterface.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "REQUESTTYPE", value = "PBRealTimeUpdateReqType" } };
            request.SystemInterfaces.SystemInterface = new SystemInterface[] { sysinterface };
            COREFile corefile = new COREFile();
            corefile.POSTDT = "01/10/2019";
            corefile.COREFileItem = new COREFileItem[]
            {
                new COREFileItem { name = "DEPTID", value = "301" },
                new COREFileItem { name = "FILENAME", value = "1234567890" },
                new COREFileItem { name = "FILETYPE", value = "S" },
                new COREFileItem { name = "FILEDESC", value = "vgonzales" },
                new COREFileItem { name = "OPEN_USERID", value = "vgonzales" },
                new COREFileItem { name = "CREATOR_USERID", value = "vgonzales" },
                new COREFileItem { name = "OPENDT", value = "01/10/2019 10:28:37" },
                new COREFileItem { name = "EFFECTIVEDT", value = "01/10/2019" },
                new COREFileItem { name = "SOURCE_TYPE", value = "Cashier" }
            };
            COREEvent coreevent = new COREEvent();
            coreevent.ReceiptReferenceNbr = "1234567890-1";
            Transactions transactions = new Transactions();
            transactions.Count = "2";
            Transaction tra1 = new Transaction();
            tra1.TransactionItem = new TransactionItem[]
            {
                new TransactionItem { name = "TRANNBR", value = "2" }
            };
            Transaction tra2 = new Transaction();
            tra2.TransactionItem = new TransactionItem[]
            {
                new TransactionItem { name = "TRANNBR", value = "3" }
            };
            transactions.Transaction = new Transaction[] { tra1, tra2 };
            coreevent.Transactions = new Transactions[] { transactions };
            TTA tta1 = new TTA();
            tta1.TRANNBR = "3";
            TTA tta2 = new TTA();
            tta2.TRANNBR = "2";
            coreevent.TTAMAPPING = new TTA[] { tta1, tta2 };
            corefile.COREEvents = new COREEvents[] { new COREEvents { COREEvent = new COREEvent[] { coreevent } } };
            request.COREFile = new COREFile[] { corefile };
            return request;
        }

        public static InquiryMatch CreateSingleEntityMatch()
        {
            InquiryMatch result = new InquiryMatch();
            result.CustomerInfo = Fake<CustomerInformation>.Begin().Build();
            InvoiceInformation invoice = Fake<InvoiceInformation>.Begin().Build();
            result.InvoiceList.Add(invoice);
            result.ResultType = MatchType.SingleEntityMatch;

            InvoiceItem detail = Fake<InvoiceItem>.Begin().Build();
            result.InvoiceItemList.Add(detail);

            return result;
        }

        public static InquiryMatch CreateMultiMatch()
        {
            InquiryMatch result = new InquiryMatch();
            MatchInfo match1 = Fake<MatchInfo>.Begin().Build();
            result.MatchList.Add(match1);
            MatchInfo match2 = Fake<MatchInfo>.Begin().Build();
            result.MatchList.Add(match2);
            result.ResultType = MatchType.MultiEntityMatch;
            return result;
        }

        public static InquiryMatch CreateZeroMatch()
        {
            InquiryMatch result = new InquiryMatch();
            result.ResultType = MatchType.ZeroEntityMatch;
            return result;
        }

        public static PermitMatch CreatePermitSearchResult()
        {
            PermitMatch result = new PermitMatch();
            result.PermitInfo = Fake<PermitHeader>.Begin().Build();
            result.PermitInfo.Header_DeptId = "08";
            result.PermitInfo.Header_AppId = "001";
            for (int i = 0; i < 6; i++)
            {
                InvoiceItem p = Fake<InvoiceItem>.Begin().Build();
                result.PermitItems.Add(p);
            }
            InvoiceInformation invoice = Fake<InvoiceInformation>.Begin().Build();
            result.InvoiceList.Add(invoice);
            InvoiceItem bonditem = Fake<InvoiceItem>.Begin().Build();
            result.InvoiceItemList.Add(bonditem);
            return result;
        }

        public static DataContainer CreatePermitDataResult()
        {
            DataContainer data = new DataContainer();
            data.Header = Fake<IXHeader>.Begin().Build();
            data.Address = Fake<IXAddress>.Begin().Build();
            data.Information = Fake<IXName>.Begin().Build();
            IXDetail detail1 = Fake<IXDetail>.Begin().Build();
            IXDetail detail2 = Fake<IXDetail>.Begin().Build();
            data.Details.Add(detail1);
            data.Details.Add(detail2);
            return data;
        }

        public static DataSet GetMockDataSet(Dictionary<string, string> collection, string tableName)
        {
            DataSet ds = new DataSet();
            var dt = new DataTable(tableName);

            foreach (var pair in collection)
            {
                dt.Columns.Add(pair.Key);
            }

            DataRow mockRow = dt.NewRow();

            foreach (KeyValuePair<string, string> pair in collection)
            {
                mockRow[pair.Key] = pair.Value;
            }

            dt.Rows.Add(mockRow);
            ds.Tables.Add(dt);

            return ds;
        }

        public static DataTable GetMockDataTable(Dictionary<string, string> collection, string tableName)
        {
            DataTable dt = new DataTable(tableName);

            foreach (var pair in collection)
            {
                dt.Columns.Add(pair.Key);
            }

            DataRow mockRow = dt.NewRow();

            foreach (KeyValuePair<string, string> pair in collection)
            {
                mockRow[pair.Key] = pair.Value;
            }

            dt.Rows.Add(mockRow);

            return dt;
        }

        public static string GenerateString(int minLength, int maxLength, Random rng)
        {
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] chars = new char[maxLength];
            int setLength = allowedChars.Length;
            int length = rng.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; ++i)
            {
                chars[i] = allowedChars[rng.Next(setLength)];
            }
            return new string(chars, 0, length);
        }
    }
}
