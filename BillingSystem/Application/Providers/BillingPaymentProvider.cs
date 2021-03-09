using Domain.Models;
using Infrastructure.RecurlyProvider;
using Infrastructure.Repository;
using Domain.DTOs;
using Domain.RepositoryModels;
using AutoMapper;
using System.Collections.Generic;
using NServiceBus;
using System.Threading.Tasks;

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
      
        public Account CreateAccount(AccountModel accountModel)
        {            
            var accountCreated = _mapper.Map<Account>(_recurlyAdapter.CreateAccount(accountModel));                     
            return accountCreated;
        }

        public Account CreateSubscription(SubscriptionModel subscriptionModel)
        {           
            var account = _accountRepository.GetBy(x => x.Code == subscriptionModel.AccountCode);
            if (account == null)
                return null;
            var subscriptionVM = _mapper.Map<SubscriptionDTO>(_recurlyAdapter.CreateSubscription(subscriptionModel));
            account.Subscriptions = account.Subscriptions ?? new List<SubscriptionDTO>();
            account.Subscriptions.Add(subscriptionVM);
            return account;           
        
        }
    }
}
