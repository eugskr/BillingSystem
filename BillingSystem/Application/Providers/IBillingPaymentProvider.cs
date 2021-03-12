using Domain.DTOs;
using Domain.Models;
using Domain.RepositoryModels;

namespace Application.Providers
{
    public interface IBillingPaymentProvider
    {
        Account CreateAccount(AccountModel accountModel);
        Invoice CreateInvoice(InvoiceModel invoiceModel);
        Account CreateSubscription(SubscriptionModel subscriptionModel);
    }
}
