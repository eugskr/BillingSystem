using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.Mediators;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AccountController : ControllerBase
    {        
        private readonly IBillingPaymentMediator _billingPaymentMediator;

        public AccountController(IBillingPaymentMediator billingPaymentMediator)
        {            
            _billingPaymentMediator = billingPaymentMediator;
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(AccountCreate accountModel)
        {          
            return Created(Request?.Path.Value, await _billingPaymentMediator.CreateAccountAsync(accountModel));
        }

        [HttpPost]
        [Route("CreateSubscription")]
        public async Task<IActionResult> CreateSubscription(SubscriptionCreate subscriptionModel)
        {
            var accountModel = await _billingPaymentMediator.CreateSubscriptionAsync(subscriptionModel);
            if (accountModel == null)
                return BadRequest("Account doesn't exist");
            return Created(Request?.Path.Value, accountModel);
        }

        [HttpPost]
        [Route("CreateSubscriptionViaPURCHASE")]
        public  IActionResult CreateSubscriptionViaPurchase(SubscriptionCreate subscriptionModel)
        {
             _billingPaymentMediator.CreateSubscription(subscriptionModel);
            
            return Ok();
        }
    }
}
