using Domain.Models;
using Recurly.Resources;

namespace Application.Strategy
{
    public interface ISubscriptionStrategy
    {
        PurchaseCreate CreatePurchase(SubscriptionModel subscriptionModel);
    }
}
