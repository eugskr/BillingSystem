using Application.Extensions;
using Domain.Models;
using Infrastructure.RecurlyProvider;
using Recurly.Resources;

namespace Application.Strategy
{
    public class MonthlySubscriptionPlan : ISubscriptionStrategy
    {          
        public PurchaseCreate CreatePurchase(Domain.Models.SubscriptionCreate subscriptionModel)
        {
            (int recurringPayment, int remainderPayment) = (subscriptionModel.UnitAmount, Constants.MonthlyPayment).RecurringAndRemainderPaymentCalc();

            var purchaseCreate = new PurchaseCreateBuilder()
                .BuildAccount(subscriptionModel.AccountCode)
                .BuildCollectionMethod()
                .BuildCurrency()
                .BuildSubscriptions(Constants.MONTHLY_PLAN, recurringPayment)
                .BuildLineItems(recurringPayment, Constants.LAST_MONTH);

            purchaseCreate = remainderPayment > 0 ?
                purchaseCreate.BuildLineItems(remainderPayment, Constants.REMAINDER) :
                purchaseCreate;
            return purchaseCreate.GetPurchaseCreate();
        }
    }
}
