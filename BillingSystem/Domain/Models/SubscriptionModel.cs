using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class SubscriptionModel
    {
        public string Currency { get; set; }
        public string AccountCode { get; set; }
        public string PlanCode { get; set; }
        public int Premium { get; set; }
    }
}
