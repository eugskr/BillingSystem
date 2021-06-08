using Domain.Models;
using Domain.RepositoryModels;

namespace Application.Providers
{
    public interface IBillingPaymentProvider
    {
        Account CreateAccount(AccountCreate accountModel);
        //Invoice CreateInvoice(InvoiceCreate invoiceModel);
        Account CreateSubscription(SubscriptionCreate subscriptionModel);
        Account CreateSubscriptionViaPurchase(SubscriptionCreate subscriptionModel);
    }
}
