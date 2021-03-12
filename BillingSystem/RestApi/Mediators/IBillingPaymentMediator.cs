using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Mediators
{
    public interface IBillingPaymentMediator
    {
        Task<AccountDTO> CreateAccountAsync(AccountModel accountModel);
        Task<InvoiceDTO> CreateInvoiceAsync(InvoiceModel invoiceModel);
        Task<AccountDTO> CreateSubscriptionAsync(SubscriptionModel subscriptionModel);
    }
}
