using Domain.Responses;
using Domain.Models;
using System.Threading.Tasks;

namespace RestApi.Mediators
{
    public interface IBillingPaymentMediator
    {
        Task<AccountResponse> CreateAccountAsync(AccountCreate accountModel);       
        Task<AccountResponse> CreateSubscriptionAsync(SubscriptionCreate subscriptionModel);
        Task<AccountResponse> CreateSubscription(SubscriptionCreate subscriptionModel);
    }
}
