using Domain.Models;
using Recurly.Resources;

namespace Infrastructure.RecurlyProvider
{
    public interface IRecurlyAdapter
    {
        Account CreateAccount(AccountModel model);
        InvoiceCollection CreateInvoice(InvoiceModel invoiceModel);
        Subscription CreateSubscription(SubscriptionModel subscriptionModel);       
        InvoiceCollection CreateSubscriptionViaPurchase(PurchaseCreate purchaseCreate);
    }
}
