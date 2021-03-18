using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.Mediators;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IBillingPaymentMediator _billingPaymentMediator;

        public InvoiceController(IBillingPaymentMediator billingPaymentMediator)
        {
            _billingPaymentMediator = billingPaymentMediator;
        }

        [HttpPost]
        [Route("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice(InvoiceModel invoiceModel)
        {
            return Created(Request?.Path.Value, await _billingPaymentMediator.CreateInvoiceAsync(invoiceModel));
        }
    }
}
