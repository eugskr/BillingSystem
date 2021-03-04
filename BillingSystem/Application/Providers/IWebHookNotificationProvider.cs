using Domain.WebHookNotificationModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Application.Providers
{
    public interface IWebHookNotificationProvider
    {
        public void ProcessWithXml(XmlDocument xmlDoc);
    }
}
