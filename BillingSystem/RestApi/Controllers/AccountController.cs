using Application.Providers;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;


namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IBillingPaymentProvider _billingPaymentProvider;
 

        public AccountController(IBillingPaymentProvider billingPaymentProvider)
        {
            _billingPaymentProvider = billingPaymentProvider;
           
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel model)
        {
            return Ok(_billingPaymentProvider.CreateAccount(model));
        }

       
    }
}
