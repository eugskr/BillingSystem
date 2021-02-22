using Recurly;
using Recurly.Resources;
using Domain.Models; 

namespace Infrastructure.RecurlyProvider
{
    class RecurlyAdapter : IRecurlyAdapter
    {
        private readonly Client client;
        public RecurlyAdapter()
        {
            client = new Client(Settings.Default.ApiKey);
        }

        public Account CreateAccount(AccountModel accountModel)
        {
            var accountReq = new AccountCreate()
            {
                Code = accountModel.Code,
                FirstName = accountModel.FirstName,
                LastName = accountModel.LastName,
            };
            return client.CreateAccount(accountReq);
        }

        public Subscription CreateSubscription(SubscriptionModel subscriptionModel)
        {
            var subReq = new SubscriptionCreate()
            {
                Currency = subscriptionModel.Currency,
                Account = new AccountCreate()
                {
                    Code = subscriptionModel.AccountCode

                },
                PlanCode = subscriptionModel.PlanCode,
                UnitAmount = subscriptionModel.Premium,
                CollectionMethod = "manual"
            };  
            return client.CreateSubscription(subReq);
        }
       
    }
}
