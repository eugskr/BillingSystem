using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class AccountDTO
    {       
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<SubscriptionDTO> Subscriptions { get; set; }
    }
}
