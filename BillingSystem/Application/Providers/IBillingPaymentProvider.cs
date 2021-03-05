using Domain.DTOs;
using Domain.Models;
using Domain.RepositoryModels;

namespace Application.Providers
{
    public interface IBillingPaymentProvider
    {
        Account CreateAccount(AccountModel accountModel);
        Account CreateSubscription(SubscriptionModel subscriptionModel);
    }
}
