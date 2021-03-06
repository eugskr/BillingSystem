﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain.WebHookNotificationModels
{
    public class PaymentNotificationBase: IMessage
    {
        [XmlElement("account")]
        public Account Account { get; set; }

        [XmlElement("transaction")]
        public Transaction Transaction { get; set; }
    }
}
