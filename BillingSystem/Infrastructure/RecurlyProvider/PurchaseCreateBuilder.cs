using Recurly.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RecurlyProvider
{
    public class PurchaseCreateBuilder
    {
        private readonly PurchaseCreate _purchaseCreate;
        public PurchaseCreateBuilder()
        {
            _purchaseCreate = new PurchaseCreate { LineItems = new List<LineItemCreate>(), Subscriptions = new List<SubscriptionPurchase>() };
        }
     
        public PurchaseCreate GetPurchaseCreate() => _purchaseCreate;

        public PurchaseCreateBuilder BuildAccount(string accountCode)
        {
            _purchaseCreate.Account = new AccountPurchase() { Code = accountCode };

            return this;
        }

        public PurchaseCreateBuilder BuildCurrency()
        {
            _purchaseCreate.Currency = Constants.UAH;

            return this;
        }

        public PurchaseCreateBuilder BuildCollectionMethod()
        {
            _purchaseCreate.CollectionMethod = Constants.MANUAL;

            return this;
        }

        public PurchaseCreateBuilder BuildSubscriptions(string planCode, int cyclePayment)
        {
            _purchaseCreate.Subscriptions.Add(
                 new SubscriptionPurchase()
                 {
                     PlanCode = planCode,
                     UnitAmount = cyclePayment,
                 });  
            return this;
        }  

        public PurchaseCreateBuilder BuildLineItems(float? unitAmount, string description)
        {
            _purchaseCreate.LineItems.Add(
                new LineItemCreate
                {
                    Type = Constants.CHARGE,
                    UnitAmount = unitAmount,
                    Currency = Constants.UAH,
                    Description = description
                });
            return this;
        }
    }
}
