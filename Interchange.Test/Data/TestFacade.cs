using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interchange.Data;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Interchange.Test.Data
{
    [TestClass]
    public class TestFacade
    {
        private AbstractFacade sut;

        [TestInitialize]
        public void InitializeTest()
        { }

        [TestMethod]
        public void StoredProcFacade_Test_Helpers()
        {
            // Arrange
            sut = new StoredProcFacade();
            sut.ConnectionString = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=abc.acme)));USER ID=userid;PASSWORD=password;Pooling=true;";
            sut.SetStoredProc("mockStoredProcedure");
            sut.AddParamInDate("mockDate", DateTime.Now);
            sut.AddParamInString("mockString", string.Empty);
            sut.AddParamInInt32("mockInteger", int.MinValue);
            sut.AddParamInIntNullable("mockIntegerNullable", null);
            sut.AddParamInInt64("mockInteger64", Int64.MinValue);
            sut.AddParamInDecimal("mockDecimal", decimal.MinValue);
            sut.AddParamOutInt32("mockIntegerOut", 1000);
            sut.AddParamOutRefCursor("mockOutRefCursor", 1000);
            OracleParameter param1 = new OracleParameter("intOut", OracleDbType.Int32)
            {
                OracleDbType = OracleDbType.Int32,
                Size = 1000,
                Direction = ParameterDirection.Output
            };
            sut.CMD.Parameters.Add(param1);
            sut.CMD.Parameters["intOut"].Value = 20;
            OracleParameter param2 = new OracleParameter("stringOut", OracleDbType.Varchar2)
            {
                OracleDbType = OracleDbType.Varchar2,
                Size = 1000,
                Direction = ParameterDirection.Output
            };
            sut.CMD.Parameters.Add(param2);
            sut.CMD.Parameters["stringOut"].Value = "stringOutput";
            sut.AddParamOutDecimal("mockDecimalOut");
            sut.AddParamOutString("mockStringOut", 1000);

            // Act
            var result1 = sut.GetParamOutInt32("intOut");
            var result2 = sut.GetParamOutString("stringOut");
            var result3 = sut.ParamsValue();

            // Assert
            Assert.AreEqual(result1, 20);
            Assert.AreEqual(result2, "stringOutput");
            Assert.IsNotNull(result3);
        }

        [TestMethod]
        public void AbstractFacade_Test_Helpers()
        {
            // Arrange
            sut = new MockFacade();
            sut.ConnectionString = "DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=abc.acme)));USER ID=userid;PASSWORD=password;Pooling=true;";
            sut.SetStoredProc("mockStoredProcedure");
            sut.AddParamInDate("mockDate", DateTime.Now);
            sut.AddParamInString("mockString", string.Empty);
            sut.AddParamInInt32("mockInteger", int.MinValue);
            sut.AddParamInIntNullable("mockIntegerNullable", null);
            sut.AddParamInInt64("mockInteger64", Int64.MinValue);
            sut.AddParamInDecimal("mockDecimal", decimal.MinValue);
            sut.AddParamOutInt32("mockIntegerOut", 1000);
            //storedProcFacade.AddParamOutRefCursor("mockOutRefCursor", 1000);
            SqlParameter param1 = new SqlParameter("intOut", SqlDbType.Int)
            {
                SqlDbType = SqlDbType.Int,
                Size = 1000,
                Direction = ParameterDirection.Output
            };
            sut.CMD.Parameters.Add(param1);
            sut.CMD.Parameters["intOut"].Value = 20;
            SqlParameter param2 = new SqlParameter("stringOut", SqlDbType.VarChar)
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 1000,
                Direction = ParameterDirection.Output
            };
            sut.CMD.Parameters.Add(param2);
            sut.CMD.Parameters["stringOut"].Value = "stringOutput";
            sut.AddParamOutDecimal("mockDecimalOut");
            sut.AddParamOutString("mockStringOut", 1000);

            // Act
            var result1 = sut.GetParamOutInt32("intOut");
            var result2 = sut.GetParamOutString("stringOut");
            var result3 = sut.ParamsValue();

            // Assert
            Assert.AreEqual(result1, 20);
            Assert.AreEqual(result2, "stringOutput");
            Assert.IsNotNull(result3);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            sut.CloseConnection();
        }
        public class MockFacade : AbstractFacade
        { }
    }
}
