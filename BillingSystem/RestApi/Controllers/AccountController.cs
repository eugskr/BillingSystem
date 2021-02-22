using Application.Providers;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;


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
            return Ok(_billingPaymentProvider.CreateAccount(accountModel));
        }

        [HttpPost]
        [Route("CreateSubscription")]

        public IActionResult CreateSubscrption(SubscriptionModel subscriptionModel)
        {
            return Ok(_billingPaymentProvider.CreateSubscription(subscriptionModel));
        }
    }
}
