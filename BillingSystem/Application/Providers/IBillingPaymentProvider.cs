using Domain.Models;

namespace Application.Providers
{
    public interface IBillingPaymentProvider
    {
        AccountVM CreateAccount(AccountModel model);
    }
}
