using Domain.Responses;
using MongoDB.Bson.Serialization.Attributes;
using NServiceBus;
using System;
using System.Collections.Generic;

namespace Domain.RepositoryModels
{
    public class Account: IMessage
    {        
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SubscriptionResponse> Subscriptions { get; set; }
        public List<InvoiceResponse> Invoices { get; set; }
    }
}
