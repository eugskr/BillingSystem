using Domain.WebHookNotificationModels;
using Infrastructure.Repository;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    public class PaymentNotificationHandler : IHandleMessages<PaymentNotificationBase>
    {
        private readonly IDbRepository<PaymentNotificationBase> _dbClient;

        public PaymentNotificationHandler(IDbRepository<PaymentNotificationBase> dbClient)
        {
            _dbClient = dbClient;
        }

        static ILog log = LogManager.GetLogger<PaymentNotificationBase>();
        public async Task Handle(PaymentNotificationBase paymentNotificationModel, IMessageHandlerContext context)
        {
            log.Info($"Received PaymentNotification");
            await _dbClient.Insert(paymentNotificationModel);
            log.Info($"Saved PaymentNotification in DB");

        }
    }
}
