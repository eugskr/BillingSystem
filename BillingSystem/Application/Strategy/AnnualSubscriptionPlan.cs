using Application.Extensions;
using Domain.Models;
using Infrastructure.RecurlyProvider;
using Recurly.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Application.Strategy
{
    public class AnnualSubscriptionPlan: ISubscriptionStrategy
    {               
        public PurchaseCreate CreatePurchase(Domain.Models.SubscriptionCreate subscriptionModel)
        {
            
            var purchaseCreate = new PurchaseCreateBuilder()
                .BuildAccount(subscriptionModel.AccountCode)
                .BuildCollectionMethod()
                .BuildCurrency()
                .BuildSubscriptions(Constants.MONTHLY_PLAN, subscriptionModel.UnitAmount)
                .GetPurchaseCreate();

           
            return purchaseCreate;
        }
    }
}
