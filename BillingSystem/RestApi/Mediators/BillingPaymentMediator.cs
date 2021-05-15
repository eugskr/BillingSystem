using Application.Providers;
using AutoMapper;
using Domain.DTOs;
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
        public async Task<AccountDTO> CreateAccountAsync(AccountModel accountModel)
        {
            var account = _billingPaymentProvider.CreateAccount(accountModel);
            var accountDto = _mapper.Map<AccountDTO>(account);          
            await _messageSession.Send(account); 
            return accountDto;
        }
        public async Task<AccountDTO> CreateSubscriptionAsync(SubscriptionModel subscriptionModel)
        {
            var account = _billingPaymentProvider.CreateSubscription(subscriptionModel);
            if (account == null)
                return null;
            var accountDto = _mapper.Map<AccountDTO>(account);
            await _messageSession.Send(account);
            return accountDto;
        }

        public async Task<InvoiceDTO> CreateInvoiceAsync(InvoiceModel invoiceModel)
        {
            var invoice = _billingPaymentProvider.CreateInvoice(invoiceModel);
            var invoiceDto = _mapper.Map<InvoiceDTO>(invoice);
            await _messageSession.Send(invoice);
            return invoiceDto;
        }
        public  void CreateSubViaPurchase(SubscriptionModel subscriptionModel)
        {
            _billingPaymentProvider.CreateSubscriptionViaPurchase(subscriptionModel);           
           
        }
    }
}
