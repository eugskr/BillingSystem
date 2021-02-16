using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using Recurly.Resources;

namespace Infrastructure.RecurlyProvider
{
    class RecurlyAccount : IRecurlyAccount
    {
        private readonly Client client;
        public RecurlyAccount()
        {
            client = new Client(Settings.Default.ApiKey);
        }
        public  void CreateAccount()
        {
            var accountReq = new AccountCreate()
            {
                Code = "EU3141",
                FirstName = "Benjamin",
                LastName = "Du Monde",
            };
            Account account = client.CreateAccount(accountReq);

        }
    }
}
