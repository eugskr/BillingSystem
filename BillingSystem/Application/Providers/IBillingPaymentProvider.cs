using Domain.Models;

namespace Application.Providers
{
    public interface IBillingPaymentProvider
    {
        AccountViewModel CreateAccount(AccountModel model);
    }
}
