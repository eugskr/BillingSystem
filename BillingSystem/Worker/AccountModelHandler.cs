using Domain.RepositoryModels;
using Infrastructure.Repository;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Worker
{
    public class AccountModelHandler : IHandleMessages<Account>
    {
        private readonly IDbRepository<Account> _dbClient;
        static ILog log = LogManager.GetLogger<Account>();
        public AccountModelHandler(IDbRepository<Account> dbClient)
        {
            _dbClient = dbClient;
        }
        public async Task Handle(Account account, IMessageHandlerContext context)
        {
            log.Info($"Received Account, AccountCode = {account.Code}");
            await _dbClient.Upsert(account, account.Id);
            log.Info($"Saved Account in DB, AccountCode = {account.Code}");
        }
    }
}
