using Domain.DTOs;
using System;
using System.Collections.Generic;

namespace Domain.RepositoryModels
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<SubscriptionDTO> Subscriptions { get; set; }
    }
}
