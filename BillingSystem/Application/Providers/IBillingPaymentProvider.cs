using Domain.DTOs;
using Domain.Models;
using System.Threading.Tasks;

namespace Application.Providers
{
    public interface IBillingPaymentProvider
    {
        AccountDTO CreateAccount(AccountModel accountModel);
        AccountDTO CreateSubscription(SubscriptionModel subscriptionModel);
    }
}
