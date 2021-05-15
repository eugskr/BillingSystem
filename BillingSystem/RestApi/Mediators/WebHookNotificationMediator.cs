using Application.Providers;
using NServiceBus;
using System.Threading.Tasks;
using System.Xml;

namespace RestApi.Mediators
{
    public class WebHookNotificationMediator: IWebHookNotificationMediator
    {
        private readonly IMessageSession _messageSession;
        private readonly IWebHookNotificationProvider _webHookNotificationProvider;

        public WebHookNotificationMediator(IWebHookNotificationProvider webHookNotificationProvider, IMessageSession messageSession)
        {
            _webHookNotificationProvider = webHookNotificationProvider;
            _messageSession = messageSession;
        }
        public async Task ProcessWithXmlAsync(XmlDocument xmlDoc)
        {
           var paymentNotificationModel= _webHookNotificationProvider.ProcessWithXml(xmlDoc);
            if (paymentNotificationModel == null)
                return;
           await _messageSession.Send(paymentNotificationModel);
        }
    }
}
