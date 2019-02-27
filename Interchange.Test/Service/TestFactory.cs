using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interchange.WCF;
using Interchange.Entity;
using Moq;
using Interchange.Data;
using System.Data;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace Interchange.Test.Service
{
    [TestClass]
    public class TestFactory
    {
        private Mock<AbstractFacade> mockFacade;
        private Factory sut;

        [TestInitialize]
        public void InitializeTest()
        {
            mockFacade = new Mock<AbstractFacade>();
            sut = new Factory(mockFacade.Object);
        }

        [TestMethod]
        public void GetRequest_For_Invoice_Should_Return_InquiryResponse3()
        {
            // Arrange
            InquiryRequest mockInquiryRequest = MockData.CreateInquiryRequest("InterchangeUpdate", new QueryKey { name = "Header_ApplicationNbr", value = "test" });
            InquiryResponse3 mockInquiryResponse = MockData.CreateInquiryResponse3();
            DataSet ds = new DataSet();

            Dictionary<string, string> custinfo = new Dictionary<string, string>();
            Random rng = new Random();
            custinfo.Add("HEADER_CUSTOMERNBR", MockData.GenerateString(4, 20, rng));
            custinfo.Add("NAME_FULLNAME", MockData.GenerateString(4, 20, rng));
            custinfo.Add("NAME_LNAME", MockData.GenerateString(4, 20, rng));
            custinfo.Add("NAME_FNAME", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_FULLADDRESS", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_NBRRANGESTART", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_NBRRANGEEND", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_FRACRANGESTART", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_FRACRANGEEND", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_UNITRANGESTART", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_UNITRANGEEND", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_STRDIR", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_STRNAME", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_STRSUFF", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_STRSUFFDIR", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_POBOX", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_CITYNAME", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_STATECODE", MockData.GenerateString(4, 20, rng));
            custinfo.Add("ADDRESS_ZIPCODE", MockData.GenerateString(4, 20, rng));
            ds.Tables.Add(MockData.GetMockDataTable(custinfo, "Table"));

            Dictionary<string, string> invoicelist = new Dictionary<string, string>();
            invoicelist.Add("HEADER_APPLICATIONNBR", MockData.GenerateString(4, 20, rng));
            invoicelist.Add("HEADER_FEEAMT", "2.75");
            invoicelist.Add("HEADER_AMTPAID", "2.75");
            invoicelist.Add("HEADER_AMOUNTDUE", "0.00");
            invoicelist.Add("HEADER_BALANCE", "0.00");
            ds.Tables.Add(MockData.GetMockDataTable(invoicelist, "Table1"));

            Dictionary<string, string> lineitems = new Dictionary<string, string>();
            lineitems.Add("HEADER_APPLICATIONNBR", MockData.GenerateString(4, 20, rng));
            lineitems.Add("DETAIL_DEPT", MockData.GenerateString(4, 20, rng));
            lineitems.Add("DETAIL_FUND", MockData.GenerateString(4, 20, rng));
            lineitems.Add("DETAIL_REVENUECODE", MockData.GenerateString(4, 20, rng));
            lineitems.Add("DETAIL_SUBREVENUECODE", MockData.GenerateString(4, 20, rng));
            lineitems.Add("DETAIL_BALANCESHEET", MockData.GenerateString(4, 20, rng));
            lineitems.Add("DETAIL_DESCRIPTION", MockData.GenerateString(4, 20, rng));
            lineitems.Add("DETAIL_FEEAMT", "2.75");
            lineitems.Add("DETAIL_AMTPAID", "5.25");
            lineitems.Add("DETAIL_BALANCE", "1.45");
            lineitems.Add("DETAIL_FEESORT", "1");
            ds.Tables.Add(MockData.GetMockDataTable(lineitems, "Table2"));
            OracleCommand _cmd = new OracleCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "FSS_POS_PACK.GET_TRANSACTION",
                Connection = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=abc.acme)));USER ID=userid;PASSWORD=password;Pooling=true;")
            };
            var param = new OracleParameter("p_warning", OracleDbType.NVarchar2)
            {
                OracleDbType = OracleDbType.Varchar2,
                Size = 1000,
                Direction = ParameterDirection.Output
            };
            _cmd.Parameters.Add(param);
            _cmd.Parameters["p_warning"].Value = "test";
            mockFacade.Setup(f => f.CMD).Returns(_cmd);
            mockFacade.Setup(f => f.FillDataSet()).Returns(ds);

            // Act
            var result = sut.GetRequest(mockInquiryRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InquiryResponse3));
            Assert.AreEqual(MatchType.SingleEntityMatch.ToString(), result.Type);
        }

        [TestMethod]
        public void GetRequest_For_Permit_Should_Return_InquiryResponse3()
        {
            // Arrange
            InquiryRequest mockInquiryRequest = MockData.CreateInqReq4Permit("InterchangeUpdate", new QueryKey { name = "Header_ApplicationNbr", value = "test" });
            InquiryResponse3 mockInquiryResponse = MockData.CreateInquiryResponse3();
            DataSet ds = new DataSet();

            Dictionary<string, string> permitInfo = new Dictionary<string, string>();
            Random rng = new Random();
            permitInfo.Add("NAME_FULLNAME", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("ADDRESS_JOBADDRESS", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("HEADER_APPLICATIONNBR", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("HEADER_BARCODE", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("HEADER_ISBLDCRD", "F");
            permitInfo.Add("HEADER_ISBLDPERMIT", "F");
            permitInfo.Add("HEADER_NOOFPERMITS", "1");
            permitInfo.Add("HEADER_RPRNBR", "1");
            permitInfo.Add("HEADER_BUILDINGCARDNBR", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("HEADER_GROUPING", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("HEADER_CUSTOMERNBR", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("HEADER_ORIGIN", MockData.GenerateString(4, 20, rng));
            permitInfo.Add("HEADER_BALANCE", "12.95");
            ds.Tables.Add(MockData.GetMockDataTable(permitInfo, "Table"));

            Dictionary<string, string> permitItem = new Dictionary<string, string>();
            permitItem.Add("HEADER_APPLICATIONNBR", MockData.GenerateString(4, 20, rng));
            permitItem.Add("DETAIL_FEESORT", "1");
            permitItem.Add("DETAIL_DESCRIPTION", MockData.GenerateString(4, 20, rng));
            permitItem.Add("DETAIL_BALANCE", "1.00");
            permitItem.Add("DETAIL_DEPT", MockData.GenerateString(4, 20, rng));
            permitItem.Add("DETAIL_FUND", MockData.GenerateString(4, 20, rng));
            permitItem.Add("DETAIL_REVENUECODE", MockData.GenerateString(4, 20, rng));
            permitItem.Add("DETAIL_SUBREVENUECODE", MockData.GenerateString(4, 20, rng));
            permitItem.Add("DETAIL_BALANCESHEET", MockData.GenerateString(4, 20, rng));
            ds.Tables.Add(MockData.GetMockDataTable(permitItem, "Table1"));

            Dictionary<string, string> bondinfo = new Dictionary<string, string>();
            bondinfo.Add("HEADER_APPLICATIONNBR", MockData.GenerateString(4, 20, rng));
            bondinfo.Add("DETAIL_BALANCE", "1.45");
            ds.Tables.Add(MockData.GetMockDataTable(bondinfo, "Table2"));

            Dictionary<string, string> bonditems = new Dictionary<string, string>();
            bonditems.Add("HEADER_APPLICATIONNBR", MockData.GenerateString(4, 20, rng));
            bonditems.Add("DETAIL_FEESORT", "1");
            bonditems.Add("DETAIL_DESCRIPTION", MockData.GenerateString(4, 20, rng));
            bonditems.Add("DETAIL_FEEAMT", "2.75");
            bonditems.Add("DETAIL_AMTPAID", "2.75");
            bonditems.Add("DETAIL_BALANCE", "0.00");
            ds.Tables.Add(MockData.GetMockDataTable(bonditems, "Table3"));

            OracleCommand _cmd = new OracleCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "PCIS_POS_PACK.GETTRANSACTION",
                Connection = new OracleConnection("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=abc.acme)));USER ID=userid;PASSWORD=password;Pooling=true;")
            };
            var param1 = new OracleParameter("p_warning", OracleDbType.NVarchar2)
            {
                OracleDbType = OracleDbType.Varchar2,
                Size = 1000,
                Direction = ParameterDirection.Output
            };
            _cmd.Parameters.Add(param1);
            _cmd.Parameters["p_warning"].Value = "test";
            var param2 = new OracleParameter("p_error", OracleDbType.NVarchar2)
            {
                OracleDbType = OracleDbType.Varchar2,
                Size = 1000,
                Direction = ParameterDirection.Output
            };
            _cmd.Parameters.Add(param2);
            _cmd.Parameters["p_error"].Value = "";
            mockFacade.Setup(f => f.CMD).Returns(_cmd);
            mockFacade.Setup(f => f.FillDataSet()).Returns(ds);

            // Act
            var result = sut.GetRequest(mockInquiryRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InquiryResponse3));
            Assert.AreEqual(MatchType.SingleEntityMatch.ToString(), result.Type);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void GetRequest_For_Invoice_Should_Return_Exception()
        {
            // Arrange
            InquiryRequest mockInquiryRequest = MockData.CreateInquiryRequest("InterchangeUpdate", new QueryKey { name = "Header_ApplicationNbr", value = "test" });

            // Act
            var result = sut.GetRequest(mockInquiryRequest);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void GetRequest_For_Permit_Should_Return_Exception()
        {
            // Arrange
            InquiryRequest mockInquiryRequest = MockData.CreateInqReq4Permit("InterchangeUpdate", new QueryKey { name = "Header_ApplicationNbr", value = "test" });

            // Act
            var result = sut.GetRequest(mockInquiryRequest);

            // Assert

        }

        [TestMethod]
        public void GetRequest_Should_Return_Failure()
        {
            // Arrange
            InquiryRequest mockInquiryRequest = new InquiryRequest();
            mockInquiryRequest.WorkgroupID = "test";
            mockInquiryRequest.UserID = "test";
            mockInquiryRequest.BannerID = "test";
            mockInquiryRequest.TransType = "test";
            mockInquiryRequest.CoreFileEffDT = "test";
            mockInquiryRequest.QuerySourcePage = "test";

            SystemInterface si = new SystemInterface();
            si.Description = "test";
            si.ID = "LADBSInterchangeInquiry";
            si.Type = "test";
            si.DatasourceName = "DEV";
            si.DatabaseName = "test";
            si.LoginName = "test";
            si.LoginPassword = "test";
            si.InterfaceDefinition = "test";
            si.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "test", value = "test" } };
            mockInquiryRequest.SystemInterfaces = new SystemInterfaces { SystemInterface = new SystemInterface[] { si } };

            QueryKey deptNo = new QueryKey { name = "Header_DeptId", value = "08" };
            QueryKey appNo = new QueryKey { name = "Header_AppId", value = "005" };
            QueryKey qrykey = new QueryKey { name = "Header_ApplicationNbr", value = "test" };
            mockInquiryRequest.QueryKeys = new QueryKeys { QueryKey = new QueryKey[] { deptNo, appNo, qrykey } };

            // Act
            var result = sut.GetRequest(mockInquiryRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InquiryResponse3));
            Assert.AreEqual(ResponseType.Failure.ToString(), result.Type);
        }

        [TestMethod]
        public void GetRequest_Should_Return_BadRequest()
        {
            // Arrange
            InquiryRequest mockInquiryRequest = new InquiryRequest();
            mockInquiryRequest.WorkgroupID = "test";
            mockInquiryRequest.UserID = "test";
            mockInquiryRequest.BannerID = "test";
            mockInquiryRequest.TransType = "test";
            mockInquiryRequest.CoreFileEffDT = "test";
            mockInquiryRequest.QuerySourcePage = "test";

            SystemInterface si = new SystemInterface();
            si.Description = "test";
            si.ID = "LADBSInterchangeInquiry";
            si.Type = "test";
            si.DatasourceName = "DEV";
            si.DatabaseName = "test";
            si.LoginName = "test";
            si.LoginPassword = "test";
            si.InterfaceDefinition = "test";
            si.SystemInterfaceItem = new SystemInterfaceItem[] { new SystemInterfaceItem { name = "test", value = "test" } };
            mockInquiryRequest.SystemInterfaces = new SystemInterfaces { SystemInterface = new SystemInterface[] { si } };

            QueryKey deptNo = new QueryKey { name = "Header_DeptId", value = "69" };
            QueryKey appNo = new QueryKey { name = "Header_AppId", value = "002" };
            QueryKey qrykey = new QueryKey { name = "Header_ApplicationNbr", value = "test" };
            mockInquiryRequest.QueryKeys = new QueryKeys { QueryKey = new QueryKey[] { deptNo, appNo, qrykey } };

            // Act
            var result = sut.GetRequest(mockInquiryRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InquiryResponse3));
            Assert.AreEqual(ResponseType.Failure.ToString(), result.Type);
        }
    }
}
