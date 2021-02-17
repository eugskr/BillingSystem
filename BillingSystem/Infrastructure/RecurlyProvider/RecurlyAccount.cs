using Recurly;
using Recurly.Resources;
using Domain.Models; 

namespace Infrastructure.RecurlyProvider
{
    class RecurlyAccount : IRecurlyAdapter
    {
        private readonly Client client;
        public RecurlyAccount()
        {
            client = new Client(Settings.Default.ApiKey);
        }
        public Account CreateAccount(AccountModel model)
        {
            var accountReq = new AccountCreate()
            {
                Code = model.Code,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            return client.CreateAccount(accountReq);

        }
    }
}
