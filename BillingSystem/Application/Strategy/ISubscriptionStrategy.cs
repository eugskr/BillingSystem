using Domain.Models;
using Recurly.Resources;

namespace Application.Strategy
{
    public interface ISubscriptionStrategy
    {
        PurchaseCreate CreatePurchase(Domain.Models.SubscriptionCreate subscriptionModel);
    }
}
