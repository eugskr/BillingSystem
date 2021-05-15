﻿using Domain.Models;
using Recurly.Resources;
using System.Collections.Generic;

namespace Application.Strategy
{
    public class QuarterlySubscriptionPlan : ISubscriptionStrategy
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
                        UnitAmount = subscriptionModel.UnitAmount/4,

                    }
                },
                LineItems = new List<LineItemCreate>
                        {
                            new LineItemCreate
                            {
                               Type = Constants.CHARGE,
                               UnitAmount = subscriptionModel.UnitAmount-(subscriptionModel.UnitAmount/4)*4,
                               Currency = Constants.UAH,
                               Description="Remainder",
                            }
                        },
            };
        }
    }
}
