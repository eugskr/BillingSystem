using Domain.Models;
using Infrastructure.RecurlyProvider;
using Application.Mapper;
using Infrastructure.Repository;

namespace Application.Providers
{
    public class BillingPaymentProvider : IBillingPaymentProvider
    {
        private readonly IRecurlyAdapter _recurlyAdapter;
        private readonly IDbClient<AccountViewModel> _dbClient;
        public BillingPaymentProvider(IRecurlyAdapter recurlyAdapter, IDbClient<AccountViewModel> dbClient)
        {
            _recurlyAdapter = recurlyAdapter;
            _dbClient = dbClient;
        }
        public AccountViewModel CreateAccount(AccountModel model)
        {
            var responseModel = _recurlyAdapter.CreateAccount(model);
            var accountVM = responseModel.ToAccountResponse();
            _dbClient.AddAccount(accountVM);
            return accountVM;
        }
    }
}
