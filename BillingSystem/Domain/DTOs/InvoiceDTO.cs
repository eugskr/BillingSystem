using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class InvoiceDTO
    {
        public string InvoiceId { get; set; }
        public string AccountCode { get; set; }
        public string Currency { get; set; }
        public float Ammount { get; set; }

    }
}
