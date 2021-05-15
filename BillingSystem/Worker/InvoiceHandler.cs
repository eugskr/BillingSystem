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
    public class InvoiceHandler : IHandleMessages<Invoice>
    {
        private readonly IDbRepository<Invoice> _dbClient;

        public InvoiceHandler(IDbRepository<Invoice> dbClient)
        {
            _dbClient = dbClient;
        }
        static ILog log = LogManager.GetLogger<Invoice>();

        public async Task Handle(Invoice invoice, IMessageHandlerContext context)
        {
            log.Info($"Received Invoice");
            await _dbClient.Insert(invoice);
            log.Info($"Saved Invoice in DB");
        }
    }
}
