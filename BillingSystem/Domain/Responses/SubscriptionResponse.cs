using Domain.Models;
using System.ComponentModel;

namespace Domain.Responses
{
    public class SubscriptionResponse
    {
        public int Id { get; set; }
        public string PlanCode { get; set; }
        public string CollectionMethod { get; set; }
    }
}
