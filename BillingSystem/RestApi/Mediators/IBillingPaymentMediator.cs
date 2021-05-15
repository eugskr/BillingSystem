using Domain.DTOs;
using Domain.Models;
using System.Threading.Tasks;

namespace RestApi.Mediators
{
    public interface IBillingPaymentMediator
    {
        Task<AccountDTO> CreateAccountAsync(AccountModel accountModel);
        Task<InvoiceDTO> CreateInvoiceAsync(InvoiceModel invoiceModel);
        Task<AccountDTO> CreateSubscriptionAsync(SubscriptionModel subscriptionModel);
        void CreateSubViaPurchase(SubscriptionModel subscriptionModel);
    }
}
