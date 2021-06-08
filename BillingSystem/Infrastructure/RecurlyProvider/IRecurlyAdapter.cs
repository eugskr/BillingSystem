using Domain.Models;
using Recurly.Resources;

namespace Infrastructure.RecurlyProvider
{
    public interface IRecurlyAdapter
    {
        Account CreateAccount(Domain.Models.AccountCreate model);
       
        Subscription CreateSubscription(Domain.Models.SubscriptionCreate subscriptionModel);       
        InvoiceCollection CreateSubscriptionViaPurchase(PurchaseCreate purchaseCreate);
    }
}
