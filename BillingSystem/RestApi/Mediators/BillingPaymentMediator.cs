using Application.Providers;
using AutoMapper;
using Domain.Responses;
using Domain.Models;
using NServiceBus;
using System.Threading.Tasks;

namespace RestApi.Mediators
{
    public class BillingPaymentMediator: IBillingPaymentMediator
    {
        private readonly IMessageSession _messageSession;
        private readonly IBillingPaymentProvider _billingPaymentProvider;
        private readonly IMapper _mapper;
        public BillingPaymentMediator(IMessageSession messageSession, IBillingPaymentProvider billingPaymentProvider, IMapper mapper)
        {
            _messageSession = messageSession;
            _billingPaymentProvider = billingPaymentProvider;
            _mapper = mapper;
        }
        public async Task<AccountResponse> CreateAccountAsync(AccountCreate accountModel)
        {
            var account = _billingPaymentProvider.CreateAccount(accountModel);
            var accountResponse = _mapper.Map<AccountResponse>(account);          
            await _messageSession.Send(account); 
            return accountResponse;
        }
        public async Task<AccountResponse> CreateSubscriptionAsync(SubscriptionCreate subscriptionModel)
        {
            var account = _billingPaymentProvider.CreateSubscription(subscriptionModel);
            if (account == null)
                return null;
            var accountResponse = _mapper.Map<AccountResponse>(account);
            await _messageSession.Send(account);
            return accountResponse;
        }              
        public async Task<AccountResponse> CreateSubscription(SubscriptionCreate subscriptionModel)
        {
            var account = _billingPaymentProvider.CreateSubscriptionViaPurchase(subscriptionModel);
            await _messageSession.Send(account);
            var accountResponse = _mapper.Map<AccountResponse>(account);
            return accountResponse;
        }
    }
}
