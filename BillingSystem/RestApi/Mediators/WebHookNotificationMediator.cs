using Application.Providers;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
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
           await _messageSession.Send(paymentNotificationModel);
        }
    }
}
