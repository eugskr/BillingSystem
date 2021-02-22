using Domain.Models;
using Recurly.Resources;

namespace Infrastructure.RecurlyProvider
{
    public interface IRecurlyAdapter
    {
        Account CreateAccount(AccountModel model);
        Subscription CreateSubscription(SubscriptionModel subscriptionModel);
    }
}
