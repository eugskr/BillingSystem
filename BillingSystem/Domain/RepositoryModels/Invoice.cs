using NServiceBus;
using System;

namespace Domain.RepositoryModels
{
    public class Invoice: IMessage
    {
        public Guid Id { get; set; }
        public string InvoiceId { get; set; }
        public string AccountCode { get; set; }
        public string Currency { get; set; }
        public float Ammount { get; set; }
    }
}
