using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain.WebHookNotificationModels
{
    public class Account
    {
        [XmlElement("account_code")]
        public string accountCode { get; set; }
    }
}
