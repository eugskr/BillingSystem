using Domain.DTOs;
using Domain.Models;

namespace Application.Providers
{
    public interface IBillingPaymentProvider
    {
        AccountDTO CreateAccount(AccountModel accountModel);
        AccountDTO CreateSubscription(SubscriptionModel subscriptionModel);
    }
}
