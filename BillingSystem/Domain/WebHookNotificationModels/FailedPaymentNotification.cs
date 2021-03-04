using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain.WebHookNotificationModels
{
    [XmlRoot("failed_payment_notification")]
    public class FailedPaymentNotification: PaymentNotificationBase
    {
       
    }
}
