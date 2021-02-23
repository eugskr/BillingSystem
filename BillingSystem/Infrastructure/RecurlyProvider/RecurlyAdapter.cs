using Recurly;
using Recurly.Resources;
using Domain.Models;
using AutoMapper;

namespace Infrastructure.RecurlyProvider
{
    class RecurlyAdapter : IRecurlyAdapter
    {
        private readonly Client client;
        private readonly IMapper _mapper;

        public RecurlyAdapter(IMapper mapper)
        {
            client = new Client(Settings.Default.ApiKey);
            _mapper = mapper;
        }

        public Account CreateAccount(AccountModel accountModel)
        {
            var accountRequest = _mapper.Map<AccountCreate>(accountModel);
            return client.CreateAccount(accountRequest);
        }

        public Subscription CreateSubscription(SubscriptionModel subscriptionModel)
        {             
            var subscruptionRequest = _mapper.Map<SubscriptionCreate>(subscriptionModel);
            return client.CreateSubscription(subscruptionRequest);
        }
       
    }
}
