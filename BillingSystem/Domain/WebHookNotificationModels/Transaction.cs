using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain.WebHookNotificationModels
{
    public class Transaction
    {
        [XmlElement("date")]
        public DateTime date { get; set; }

        [XmlElement("amount_in_cents")]
        public int ammountInCents { get; set; }

        [XmlElement("status")]
        public string status { get; set; }
    }
}
