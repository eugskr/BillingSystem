using Application.Providers;
using Domain.WebHookNotificationModels;
using Microsoft.AspNetCore.Mvc;
using RestApi.Mediators;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecurlyWebHookController : ControllerBase
    {
        private readonly IWebHookNotificationMediator _webHookNotificationMediator;

        public RecurlyWebHookController(IWebHookNotificationMediator webHookNotificationMediator)
        {
            _webHookNotificationMediator = webHookNotificationMediator;
        }

        [HttpPost]
        public async Task<IActionResult> HandleWebHook()
        {
            var doc = await ExtractXmlDocFromRequest();

            await _webHookNotificationMediator.ProcessWithXmlAsync(doc);
            return Ok();
        }

        private async Task<XmlDocument> ExtractXmlDocFromRequest()
        {
            byte[] body;
            using (var ms = new MemoryStream())
            {
                await Request?.Body?.CopyToAsync(ms);
                body = ms.ToArray();
            }

            var doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(body));
            return doc;
        }


    }
}
