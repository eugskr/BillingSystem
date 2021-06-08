using Application.Automapper;
using Application.Providers;
using AutoMapper;
using Domain.Models;
using Domain.RepositoryModels;
using Domain.Responses;
using Moq;
using NServiceBus.Testing;
using RestApi.Controllers;
using RestApi.Mediators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RestApi.Tests
{
    public class BillingPaymentMediatorTests
    {
        private readonly Mock<IBillingPaymentProvider> _mockBillingPaymentProvider;
        private readonly IBillingPaymentMediator _billingPaymentMediator;
        private readonly TestableMessageSession _testableMessageSession;

        private readonly IMapper _mapper;


        public BillingPaymentMediatorTests()
        {
            _mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AccountAutomapper());
            }).CreateMapper();

            _mockBillingPaymentProvider = new Mock<IBillingPaymentProvider>();
            _testableMessageSession = new TestableMessageSession();
            _billingPaymentMediator = new BillingPaymentMediator(
                _testableMessageSession,
                _mockBillingPaymentProvider.Object,
                _mapper);
        }

        [Fact]
        public async Task CreateAccountAsync_SuccessfullCreate_SentsMessage()
        {
            var account = new Account
            {
                Code = "testCode",
                FirstName = "testName",
                LastName = "testlastName",
                Invoices = new List<InvoiceResponse>(),
                Subscriptions = new List<SubscriptionResponse>()

            };

            var request = new AccountCreate
            {
                Code = "testCode",
                FirstName = "testName",
                LastName = "testlastName"
            };

            _mockBillingPaymentProvider
                .Setup(m => m.CreateAccount(It.IsAny<AccountCreate>()))
                .Returns(account);



            var result = await _billingPaymentMediator
                .CreateAccountAsync(request);

            var message = (Account)_testableMessageSession.SentMessages[0].Message;

            Assert.NotNull(result);
            Assert.Equal(account.Code, result.Code);

            Assert.Single(_testableMessageSession.SentMessages);
            Assert.NotNull(message);
            Assert.Equal(request.Code, message.Code);
            Assert.Equal(request.FirstName, message.FirstName);
            Assert.Equal(account.Code, message.Code);
        }

        [Fact]
        public async Task CreateSubscription_AccountDoesntExist_ReturnNull()
        {
            var request = new SubscriptionCreate
            {
                AccountCode = "testCode",
                PlanCode = "monthly_plan",
                UnitAmount = 99999
            };
            _mockBillingPaymentProvider.Setup(x => x.CreateSubscription(It.IsAny<SubscriptionCreate>()))
                .Returns(()=> null);

            var result = await _billingPaymentMediator
                .CreateSubscriptionAsync(request);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateSubscription_SuccessfullCreate_SentMessage()
        {
            var request = new SubscriptionCreate
            {
                AccountCode = "testCode",
                PlanCode = "monthly_plan",
                UnitAmount = 99999
            };
            var account = new Account
            {
                Code = "testCode",
                FirstName = "testName",
                LastName = "testlastName",
                Invoices = new List<InvoiceResponse>(),
                Subscriptions = new List<SubscriptionResponse>
                {
                    new SubscriptionResponse
                    {
                        CollectionMethod = "manual",
                        PlanCode="monthly_plan"
                    }
                },
            };

            _mockBillingPaymentProvider.Setup(m =>
            m.CreateSubscription(It.IsAny<SubscriptionCreate>()))
                .Returns(account);

            var result = await _billingPaymentMediator
                .CreateSubscriptionAsync(request);

            var message = (Account)_testableMessageSession.SentMessages[0].Message;

            Assert.NotNull(result);
            Assert.Single(_testableMessageSession.SentMessages);
            Assert.Equal(request.PlanCode, result.Subscriptions[0].PlanCode);
            Assert.Equal(request.AccountCode, message.Code);
        }
    }
}
