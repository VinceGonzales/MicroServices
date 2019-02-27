using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interchange.Entity;
using FakeModel;
using Interchange.Data;
using Moq;

namespace Interchange.Test.Data
{
    [TestClass]
    public class TestDbInternal
    {
        private Mock<AbstractFacade> mockFacade;
        private DbInternal sut;

        [TestInitialize]
        public void InitializeTest()
        {
            mockFacade = new Mock<AbstractFacade>();
            sut = new DbInternal(mockFacade.Object, "LADBS_FDR_DEV");
        }

        [TestMethod]
        public void InsertTransaction_Should_Return_InterchangeId()
        {
            // Arrange
            IXHeader header = Fake<IXHeader>.Begin().Build();
            header.Header_IsBldCrd = false;
            header.Header_IsBldPermit = false;
            int interchangeId = 12;
            mockFacade.Setup(f => f.GetParamOutInt32("p_interchangeID")).Returns(interchangeId);

            // Act
            var result = sut.InsertTransaction(header);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(interchangeId, result);
        }

        [TestMethod]
        public void InsertDetails_Should_Return_Success()
        {
            // Arrange
            IXDetail detail = Fake<IXDetail>.Begin().Build();

            // Act
            var result = sut.InsertDetail(detail, 12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseType.Success.ToString(), result);
        }

        [TestMethod]
        public void InsertName_Should_Return_Success()
        {
            // Arrange
            IXName name = Fake<IXName>.Begin().Build();

            // Act
            var result = sut.InsertName(name, 12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseType.Success.ToString(), result);
        }

        [TestMethod]
        public void InsertAddress_Should_Return_Success()
        {
            // Arrange
            IXAddress address = Fake<IXAddress>.Begin().Build();

            // Act
            var result = sut.InsertAddress(address, 12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseType.Success.ToString(), result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void InsertTransaction_Should_Return_Exception()
        {
            // Arrange
            IXHeader header = Fake<IXHeader>.Begin().Build();
            header.Header_IsBldCrd = true;
            header.Header_IsBldPermit = true;
            mockFacade.Setup(f => f.GetParamOutInt32("p_interchangeID")).Throws(new Exception());

            // Act
            var result = sut.InsertTransaction(header);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void InsertDetail_Should_Return_Exception()
        {
            // Arrange
            IXDetail detail = Fake<IXDetail>.Begin().Build();
            mockFacade.Setup(f => f.Execute()).Throws(new Exception());

            // Act
            var result = sut.InsertDetail(detail, 0);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void InsertName_Should_Return_Exception()
        {
            // Arrange
            IXName name = Fake<IXName>.Begin().Build();
            mockFacade.Setup(f => f.Execute()).Throws(new Exception());

            // Act
            var result = sut.InsertName(name, 12);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void InsertAddress_Should_Return_Exception()
        {
            // Arrange
            IXAddress address = Fake<IXAddress>.Begin().Build();
            mockFacade.Setup(f => f.Execute()).Throws(new Exception());

            // Act
            var result = sut.InsertAddress(address, 12);

            // Assert

        }
    }
}
