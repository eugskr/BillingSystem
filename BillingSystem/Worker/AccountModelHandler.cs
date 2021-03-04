using Domain.Models;
using Domain.RepositoryModels;
using Infrastructure.Repository;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
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
        public Task Handle(Account account, IMessageHandlerContext context)
        {
            log.Info($"Received AccountModel, AccountCode = {account.Code}");

            _dbClient.Insert(account);

            return Task.CompletedTask;
        }
    }
}
