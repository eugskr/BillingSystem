using Domain.Models;
using Recurly.Resources;
using System.Collections.Generic;

namespace Application.Strategy
{
    public class AnnualSubscriptionPlan : ISubscriptionStrategy
    {
        public PurchaseCreate CreatePurchase(SubscriptionModel subscriptionModel)
        {
            return new PurchaseCreate()
            {
                Currency = Constants.UAH,
                CollectionMethod = Constants.MANUAL,
                Account = new AccountPurchase()
                {
                    Code = subscriptionModel.AccountCode,
                },
                Subscriptions = new List<SubscriptionPurchase>()
                {
                    new SubscriptionPurchase()
                    {
                        PlanCode = subscriptionModel.PlanCode,
                        UnitAmount = subscriptionModel.UnitAmount,
                    }
                },
             
            };
        }
    }
}
