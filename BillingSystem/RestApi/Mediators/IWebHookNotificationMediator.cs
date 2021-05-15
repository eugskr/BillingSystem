using System.Threading.Tasks;
using System.Xml;

namespace RestApi.Mediators
{
    public interface IWebHookNotificationMediator
    {
        Task ProcessWithXmlAsync(XmlDocument xmlDoc);
    }
}
