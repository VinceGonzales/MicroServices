using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interchange.WCF;
using Moq;
using Interchange.Entity;
using Interchange.Data;

namespace Interchange.Test.Service
{
    [TestClass]
    public class TestHubExternal
    {
        private Mock<IFactory> mockFactory;
        private HubExternal sut;

        [TestInitialize]
        public void InitializeTest()
        {
            mockFactory = new Mock<IFactory>();
            sut = new HubExternal(mockFactory.Object);
        }

        [TestMethod]
        public void InquiryRequest3Operation_Should_Return_InquiryResponse3()
        {
            // Arrange
            InquiryRequest mockInquiryRequest = MockData.CreateInquiryRequest("InterchangeUpdate", new QueryKey { name = "Header_ApplicationNbr", value = "test" });
            InquiryResponse3 mockInquiryResponse = MockData.CreateInquiryResponse3();
            mockFactory.Setup(r => r.GetRequest(mockInquiryRequest)).Returns(mockInquiryResponse);

            // Act
            var result = sut.InquiryRequest3Operation(mockInquiryRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InquiryResponse3));
            Assert.AreEqual(MatchType.SingleEntityMatch.ToString(), result.Type);
        }

        [TestMethod]
        public void UpdateRequestOperation_Should_Return_UpdateResponse()
        {
            // Arrange
            UpdateRequest mockUpdateRequest = MockData.CreateSingleInvoiceUpdateRequest("InterchangeUpdate");
            string receiptNo = "1234567890R";
            UpdateResponse mockUpdateResponse = MockData.CreateUpdateResponseSuccess(receiptNo);
            mockFactory.Setup(r => r.PayTransaction(mockUpdateRequest)).Returns(mockUpdateResponse);

            // Act
            var result = sut.UpdateRequestOperation(mockUpdateRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(UpdateResponse));
            Assert.AreEqual(receiptNo, result.UpdateReference);
            Assert.AreEqual(ResponseType.Success.ToString(), result.Type);
        }

        [TestMethod]
        public void VoidRequestOperation_Should_Return_VoidResponse()
        {
            // Arrange
            VoidRequest mockVoidRequest = MockData.CreateVoidRequest();
            VoidResponse mockVoidResponse = new VoidResponse();
            mockVoidResponse.Type = ResponseType.Success.ToString();
            mockFactory.Setup(r => r.VoidTransaction(mockVoidRequest)).Returns(mockVoidResponse);

            // Act
            var result = sut.VoidRequestOperation(mockVoidRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(VoidResponse));
        }
    }
}
