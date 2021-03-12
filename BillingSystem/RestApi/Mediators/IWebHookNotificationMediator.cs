using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace RestApi.Mediators
{
    public interface IWebHookNotificationMediator
    {
        Task ProcessWithXmlAsync(XmlDocument xmlDoc);
    }
}
