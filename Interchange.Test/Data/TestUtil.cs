using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interchange.Data;

namespace Interchange.Test.Data
{
    [TestClass]
    public class TestUtil
    {
        [TestMethod]
        public void GetDeptId_Should_Return_Enum_Description()
        {
            // Arrange
            string exptected = "08";

            // Act
            string result = Util.GetDeptId(Department.LADBS);

            // Assert
            Assert.AreEqual(exptected, result);
        }
    }
}
