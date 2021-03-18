using Domain.RepositoryModels;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Worker
{
    public class AccountUpdatedHandler : IHandleMessages<Account>
    {
        private readonly IDbRepository<Account> _dbClient;


        private readonly ILogger<AccountUpdatedHandler> _log;

        public AccountUpdatedHandler(IDbRepository<Account> dbClient, ILogger<AccountUpdatedHandler> log)
        {
            _dbClient = dbClient;
            _log = log;
        }
        public async Task Handle(Account account, IMessageHandlerContext context)
        {
            try
            {
                _log.LogInformation("Received Accont");

                var accountExisting = _dbClient.GetBy(x => x.Code == account.Code);
                if (accountExisting == null)
                    await _dbClient.Insert(account);
                else
                    await _dbClient.Update(account, account.Id);

                _log.LogInformation("Saved Accont into DB");

            }
            catch (Exception e)
            {
                _log.LogError(e, e.Message);
                throw;
            }

        }
    }
}
