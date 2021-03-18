using Domain.WebHookNotificationModels;
using System.Xml;

namespace Application.Providers
{
    public interface IWebHookNotificationProvider
    {
        public PaymentNotificationBase ProcessWithXml(XmlDocument xmlDoc);
    }
}
