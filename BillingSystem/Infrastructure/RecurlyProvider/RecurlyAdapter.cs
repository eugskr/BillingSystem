using Recurly;
using Recurly.Resources;
using Domain.Models;
using AutoMapper;
using System.Collections.Generic;

namespace Infrastructure.RecurlyProvider
{
    class RecurlyAdapter : IRecurlyAdapter
    {
        private readonly Client client;
        private readonly IMapper _mapper;

        public RecurlyAdapter(IMapper mapper)
        {
            client = new Client(Settings.Default.ApiKey);
            _mapper = mapper;
        }

        public Account CreateAccount(AccountModel accountModel)
        {
            return client.CreateAccount(_mapper.Map<AccountCreate>(accountModel));
        }

        public Subscription CreateSubscription(SubscriptionModel subscriptionModel)
        {
            return client.CreateSubscription(_mapper.Map<SubscriptionCreate>(subscriptionModel));
        }

        public InvoiceCollection CreateInvoice(InvoiceModel invoiceModel)
        {
            return client.CreatePurchase(
                new PurchaseCreate()
                    {
                        Account = new AccountPurchase
                        {
                            Code = invoiceModel.AccountCode
                        },
                        Currency = Constants.UAH,
                        CollectionMethod = Constants.AUTOMATIC,
                        LineItems = new List<LineItemCreate>
                        {
                            new LineItemCreate
                            {
                               Type = Constants.CHARGE,
                               UnitAmount = invoiceModel.UnitAmmount,
                               Currency = Constants.UAH,
                            }
                        },
                    });
        }
    }
}
