using Domain.Models;
using Infrastructure.RecurlyProvider;
using Infrastructure.Repository;
using Domain.Responses;
using Domain.RepositoryModels;
using AutoMapper;
using System.Collections.Generic;
using Application.Strategy;

namespace Application.Providers
{
    public class BillingPaymentProvider : IBillingPaymentProvider
    {
        private readonly IRecurlyAdapter _recurlyAdapter;
        private readonly IDbRepository<Account> _accountRepository;
        private readonly IMapper _mapper;     

        public BillingPaymentProvider(IRecurlyAdapter recurlyAdapter, IDbRepository<Account> dbClient, IMapper mapper)
        {
            _recurlyAdapter = recurlyAdapter;
            _accountRepository = dbClient;
            _mapper = mapper;    
        }
      
        public Account CreateAccount(AccountCreate accountModel)
        {            
            var accountCreated = _mapper.Map<Account>(_recurlyAdapter.CreateAccount(accountModel));                     
            return accountCreated;
        }

        public Account CreateSubscription(SubscriptionCreate subscriptionModel)
        {           
            var account = _accountRepository.GetBy(x => x.Code == subscriptionModel.AccountCode);
            if (account == null)
                return null;
            var subscriptionDto = _mapper.Map<SubscriptionResponse>(_recurlyAdapter.CreateSubscription(subscriptionModel));
            account.Subscriptions = account.Subscriptions ?? new List<SubscriptionResponse>();
            account.Subscriptions.Add(subscriptionDto);
            return account;                   
        }      

        public Account CreateSubscriptionViaPurchase(SubscriptionCreate subscriptionModel)
        {
            var purchaseCreate = SubscriptionPlanContainer.subscriptionPlanDictionary[subscriptionModel.PlanCode].CreatePurchase(subscriptionModel);
            var invoiceCollection = _recurlyAdapter.CreateSubscriptionViaPurchase(purchaseCreate);
            var invoiceDto = _mapper.Map<InvoiceResponse>(invoiceCollection);
            var account = _accountRepository.GetBy(x => x.Code == subscriptionModel.AccountCode);
            account.Invoices = account.Invoices ?? new List<InvoiceResponse>();
            account.Invoices.Add(invoiceDto);
            return account;
        }
    }
}
