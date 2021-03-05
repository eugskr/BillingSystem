using Application.Providers;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using RestApi.Mediators;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IBillingPaymentProvider _billingPaymentProvider;
        private readonly IBillingPaymentProviderMediator _billingPaymentProviderMediator;


        public AccountController(IBillingPaymentProvider billingPaymentProvider, IBillingPaymentProviderMediator billingPaymentProviderMediator)
        {
            _billingPaymentProvider = billingPaymentProvider;
            _billingPaymentProviderMediator = billingPaymentProviderMediator;
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(AccountModel accountModel)
        {
            return Created(Request?.Path.Value, await _billingPaymentProviderMediator.CreateAccountAsync(accountModel));
        }

        [HttpPost]
        [Route("CreateSubscription")]
        public async Task<IActionResult> CreateSubscription(SubscriptionModel subscriptionModel)
        {
            var accountModel = await _billingPaymentProviderMediator.CreateSubscriptionAsync(subscriptionModel);
            if (accountModel == null)
                return BadRequest("Account doesn't exist");
            return Created(Request?.Path.Value, accountModel);
        }
    }
}
