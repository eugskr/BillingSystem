using Application.Providers;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IBillingPaymentProvider _billingPaymentProvider; 

        public AccountController(IBillingPaymentProvider billingPaymentProvider)
        {
            _billingPaymentProvider = billingPaymentProvider;           
        }

        [HttpPost]
        [Route("CreateAccount")]
        public IActionResult CreateAccount(AccountModel accountModel)
        {
            return Created(Request?.Path.Value, _billingPaymentProvider.CreateAccount(accountModel));
        }

        [HttpPost]
        [Route("CreateSubscription")]
        public IActionResult CreateSubscription(SubscriptionModel subscriptionModel)
        {
            var accountModel = _billingPaymentProvider.CreateSubscription(subscriptionModel);
            if (accountModel == null)
                return BadRequest("Account doesn't exist");
            return Created(Request?.Path.Value, accountModel);
        }
    }
}
