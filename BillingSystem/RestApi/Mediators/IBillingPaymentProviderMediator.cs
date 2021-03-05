using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Mediators
{
    public interface IBillingPaymentProviderMediator
    {
        Task<AccountDTO> CreateAccountAsync(AccountModel accountModel);
        Task<AccountDTO> CreateSubscriptionAsync(SubscriptionModel subscriptionModel);
    }
}
