using Domain.WebHookNotificationModels;
using System.Xml;
using System.Xml.Serialization;

namespace Application.Providers
{
    public class WebHookNotificationProvider : IWebHookNotificationProvider
    {
        public PaymentNotificationBase ProcessWithXml(XmlDocument xmlDoc)
        {
            PaymentNotificationBase paymentNotificationModel = null;
            switch (xmlDoc.DocumentElement.Name)
            {
                case Constants.SUCCESS_PAYMENT:
                    paymentNotificationModel = DeserializeFromXml<SuccessPaymentNotification>(xmlDoc);
                    break;
                case Constants.FAILED_PAYMENT:
                    paymentNotificationModel = DeserializeFromXml<FailedPaymentNotification>(xmlDoc);
                    break;
            }
            return paymentNotificationModel;
        }

        private static T DeserializeFromXml<T>(XmlDocument document)
        {
            using (XmlReader reader = new XmlNodeReader(document))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(reader);
            }
        }
    }
}
