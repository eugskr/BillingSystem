using Domain.Models;
using Recurly.Resources;
using System.Collections.Generic;

namespace Application.Strategy
{
    public class MonthlySubscriptionPlan : ISubscriptionStrategy
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
                        UnitAmount = subscriptionModel.UnitAmount/12,

                    }
                },
                LineItems = new List<LineItemCreate>
                        {
                            new LineItemCreate
                            {
                               Type = Constants.CHARGE,
                               UnitAmount = subscriptionModel.UnitAmount/12,
                               Currency = Constants.UAH,
                               Description="Last Month",
                            },
                            new LineItemCreate
                            {
                               Type = Constants.CHARGE,
                               UnitAmount = subscriptionModel.UnitAmount-(subscriptionModel.UnitAmount/12)*12,
                               Currency = Constants.UAH,
                               Description="Remainder",
                            }
                        },
            };
            
        }

        
    }
}
