using System.Collections.Generic;

namespace Domain.Responses
{
    public class InvoiceResponse
    {        
        public string InvoiceId { get; set; }
        public string AccountCode { get; set; }
        public string Currency { get; set; }
        public List<ChargeItem> Items { get; set; }
    }
}
