using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RestApi.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
