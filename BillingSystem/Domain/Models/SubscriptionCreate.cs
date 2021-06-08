
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class SubscriptionCreate
    {                 
        public string AccountCode { get; set; }        
        public string PlanCode { get; set; }
       
        [JsonPropertyName("Premium")]
        public int UnitAmount { get; set; }
    }
}
