using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Interchange.Data;
using Interchange.WCF;
using Interchange.Entity;
using FakeModel;
using System.Collections.Generic;

namespace Interchange.Test.Service
{
    [TestClass]
    public class TestHubInternal
    {
        private Mock<IDbInternal> mockRepo;
        private HubInternal sut;

        [TestInitialize]
        public void InitializeTest()
        {
            mockRepo = new Mock<IDbInternal>();
            sut = new HubInternal(mockRepo.Object);
        }

        [TestMethod]
        public void PostHeader_Should_Return_Success()
        {
            // Arrange
            IXHeader header = Fake<IXHeader>.Begin().Build();
            mockRepo.Setup(r => r.InsertTransaction(header)).Returns(0);

            // Act
            var result = sut.PostHeader(header);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void PostDetail_Should_Return_Success()
        {
            // Arrange
            IXDetail detail = Fake<IXDetail>.Begin().Build();
            mockRepo.Setup(r => r.InsertDetail(detail, 12)).Returns(ResponseType.Success.ToString());

            // Act
            var result = sut.PostDetail(detail, "12");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseType.Success.ToString(), result);
        }

        [TestMethod]
        public void PostName_Should_Return_Success()
        {
            // Arrange
            IXName name = Fake<IXName>.Begin().Build();
            mockRepo.Setup(r => r.InsertName(name, 12)).Returns(ResponseType.Success.ToString());

            // Act
            var result = sut.PostName(name, "12");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseType.Success.ToString(), result);
        }

        [TestMethod]
        public void PostAddress_Should_Return_Success()
        {
            // Arrange
            IXAddress address = Fake<IXAddress>.Begin().Build();
            mockRepo.Setup(r => r.InsertAddress(address, 12)).Returns(ResponseType.Success.ToString());

            // Act
            var result = sut.PostAddress(address, "12");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseType.Success.ToString(), result);
        }

        [TestMethod]
        public void PostDetails_Should_Return_Success()
        {
            // Arrange
            List<IXDetail> details = new List<IXDetail>();
            IXDetail detail = Fake<IXDetail>.Begin().Build();
            details.Add(detail);
            mockRepo.Setup(r => r.InsertDetail(detail, 12)).Returns(ResponseType.Success.ToString());

            // Act
            var result = sut.PostDetails(details, "12");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseType.Success.ToString(), result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void PostHeader_Should_Return_Exception()
        {
            // Arrange
            IXHeader header = Fake<IXHeader>.Begin().Build();
            mockRepo.Setup(r => r.InsertTransaction(header)).Throws(new Exception());

            // Act
            var result = sut.PostHeader(header);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void PostDetail_Should_Return_Exception()
        {
            // Arrange
            IXDetail detail = Fake<IXDetail>.Begin().Build();
            mockRepo.Setup(r => r.InsertDetail(detail, 12)).Throws(new Exception());

            // Act
            var result = sut.PostDetail(detail, "12");

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void PostName_Should_Return_Exception()
        {
            // Arrange
            IXName name = Fake<IXName>.Begin().Build();
            mockRepo.Setup(r => r.InsertName(name, 12)).Throws(new Exception());

            // Act
            var result = sut.PostName(name, "12");

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void PostAddress_Should_Return_Exception()
        {
            // Arrange
            IXAddress address = Fake<IXAddress>.Begin().Build();
            mockRepo.Setup(r => r.InsertAddress(address, 12)).Throws(new Exception());

            // Act
            var result = sut.PostAddress(address, "12");

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void PostDetails_Should_Return_Exception()
        {
            // Arrange
            List<IXDetail> details = new List<IXDetail>();
            IXDetail detail = Fake<IXDetail>.Begin().Build();
            details.Add(detail);
            mockRepo.Setup(r => r.InsertDetail(detail, 12)).Throws(new Exception());

            // Act
            var result = sut.PostDetails(details, "12");

            // Assert

        }
    }
}
