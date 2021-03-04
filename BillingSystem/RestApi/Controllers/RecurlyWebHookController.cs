using Application.Providers;
using Domain.WebHookNotificationModels;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IWebHookNotificationProvider _webHookNotificationProvider;

        public RecurlyWebHookController(IWebHookNotificationProvider webHookNotificationProvider)
        {
            _webHookNotificationProvider = webHookNotificationProvider;
        }

        [HttpPost]
        public async Task<IActionResult> HandleWebHook()
        {
            var doc = await ExtractXmlDocFromRequest();
           
            _webHookNotificationProvider.ProcessWithXml(doc);
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
