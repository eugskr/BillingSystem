using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Domain.Responses
{
    public class AccountResponse
    {       
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<SubscriptionResponse> Subscriptions { get; set; }
        public IList<InvoiceResponse> Invoices { get; set; }

    }
}
