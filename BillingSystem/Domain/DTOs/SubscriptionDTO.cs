using Domain.Models;
using System.ComponentModel;

namespace Domain.DTOs
{
    public class SubscriptionDTO
    {
        public string Id { get; set; }             
        public string PlanCode { get; set; }
        public string CollectionMethod { get; set; }
    }
}
