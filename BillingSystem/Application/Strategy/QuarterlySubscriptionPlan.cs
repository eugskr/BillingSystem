using Application.Extensions;
using Domain.Models;
using Infrastructure.RecurlyProvider;
using Recurly.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Application.Strategy
{
    public class QuarterlySubscriptionPlan : ISubscriptionStrategy
    {
        public PurchaseCreate CreatePurchase(Domain.Models.SubscriptionCreate subscriptionModel)
        {
            (int recurringPayment, int remainderPayment) = (subscriptionModel.UnitAmount, Constants.QuarterlyPayment).RecurringAndRemainderPaymentCalc();
            var purchaseCreate = new PurchaseCreateBuilder()
                .BuildAccount(subscriptionModel.AccountCode)
                .BuildCollectionMethod()
                .BuildCurrency()
                .BuildSubscriptions(Constants.QUARTETLY_PLAN, recurringPayment);

            purchaseCreate = remainderPayment > 0 ?
                purchaseCreate.BuildLineItems(remainderPayment, Constants.REMAINDER) :
                purchaseCreate;
            return purchaseCreate.GetPurchaseCreate();
        }
    }
}
