using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain.WebHookNotificationModels
{
    [XmlRoot("successful_payment_notification")]
    public class SuccessPaymentNotification: PaymentNotificationBase
    {
      
    }
}
