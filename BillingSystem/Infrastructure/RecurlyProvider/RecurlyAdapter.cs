using Recurly;
using Recurly.Resources;
using Domain.Models;
using AutoMapper;
using System.Collections.Generic;


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

        public Account CreateAccount(Domain.Models.AccountCreate accountModel)
        {
            return client.CreateAccount(_mapper.Map<Recurly.Resources.AccountCreate>(accountModel));
        }

        public Subscription CreateSubscription(Domain.Models.SubscriptionCreate subscriptionModel)
        {
            return client.CreateSubscription(_mapper.Map<Recurly.Resources.SubscriptionCreate>(subscriptionModel));
        }
      
        public InvoiceCollection CreateSubscriptionViaPurchase(PurchaseCreate purchaseCreate)
        {            
            return client.CreatePurchase(purchaseCreate);
        }
    }
}
