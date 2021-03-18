using Domain.DTOs;
using MongoDB.Bson.Serialization.Attributes;
using NServiceBus;
using System;
using System.Collections.Generic;

namespace Domain.RepositoryModels
{
    public class Account: IMessage
    {
        //[BsonId]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SubscriptionDTO> Subscriptions { get; set; }
    }
}
