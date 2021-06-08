using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Responses
{
    public class ChargeItem
    {
        public string Description { get; set; }
        public string PlanCode { get; set; }      
        public float? UnitAmount { get; set; }
    }
}
