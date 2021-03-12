using Domain.RepositoryModels;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Worker
{
    public class AccountUpdatedHandler : IHandleMessages<Account>
    {
        private readonly IDbRepository<Account> _dbClient;
        static ILog log = LogManager.GetLogger<Account>();

        public ILogger<AccountUpdatedHandler> _log { get; }

        public AccountUpdatedHandler(IDbRepository<Account> dbClient, ILogger<AccountUpdatedHandler> log)
        {
            _dbClient = dbClient;
            _log = log;
        }
        public async Task Handle(Account account, IMessageHandlerContext context)
        {
            try
            {
                log.Info($"Received Account, AccountCode = {account.Code}");
                await _dbClient.Upsert(account, account.Id);
                log.Info($"Saved Account in DB, AccountCode = {account.Code}");
            }
            catch(Exception e)
            {
                _log.LogError(e, e.Message);
                throw;
            }
          
        }
    }
}
