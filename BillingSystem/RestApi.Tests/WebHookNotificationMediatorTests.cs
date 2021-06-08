using Application.Providers;
using Domain.WebHookNotificationModels;
using Moq;
using NServiceBus.Testing;
using RestApi.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace RestApi.Tests
{
    
    public class WebHookNotificationMediatorTests
    {
		private readonly TestableMessageSession _testableMessageSession;
        private readonly Mock<IWebHookNotificationProvider> _mockWebHookNotificationProvider;
        private readonly WebHookNotificationMediator _webHookNotificationMediator;
        public WebHookNotificationMediatorTests()
        {
            _mockWebHookNotificationProvider = new Mock<IWebHookNotificationProvider>();
            _testableMessageSession = new TestableMessageSession();
            _webHookNotificationMediator = new WebHookNotificationMediator(_mockWebHookNotificationProvider.Object, _testableMessageSession);
        }

        [Fact]
        public void ProcessWithXmlAsync_XmlDoesntExist_ReturnNull()
        {
            XmlDocument doc = new XmlDocument();
            _mockWebHookNotificationProvider
                .Setup(x => x.ProcessWithXml(It.IsAny<XmlDocument>()))
                .Returns(()=>null);
            var result = _webHookNotificationMediator.ProcessWithXmlAsync(doc);

            Assert.Null(result.AsyncState);
        }

        [Fact]
        public void ProcessWithXmlAsync_SuccessXmlDocument_MessageSent()
        {
            XmlDocument doc = new XmlDocument();

            var paymentNotification = new PaymentNotificationBase
            {
                Account = new Account
                {
                    accountCode = "testCode"
                },
                Transaction = new Transaction
                {
                    ammountInCents = 3454364,
                    date = DateTime.Now,
                    status = "active"
                }
            };

            _mockWebHookNotificationProvider
                .Setup(x => x.ProcessWithXml(It.IsAny<XmlDocument>()))
                .Returns(paymentNotification);
            var result = _webHookNotificationMediator.ProcessWithXmlAsync(doc);

            var message = (PaymentNotificationBase)_testableMessageSession.SentMessages[0].Message;


        }
    }
}
