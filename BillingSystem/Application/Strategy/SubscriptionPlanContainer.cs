using System.Collections.Generic;

namespace Application.Strategy
{
    public class SubscriptionPlanContainer
    {
        public static Dictionary<string, ISubscriptionStrategy> subscriptionPlanDictionary { get; }
        static SubscriptionPlanContainer()
        {
            subscriptionPlanDictionary = new Dictionary<string, ISubscriptionStrategy>
            {
                {                    
                    Constants.MONTHLY_PLAN,
                    new MonthlySubscriptionPlan()
                },
                {
                    Constants.QUARTETLY_PLAN,
                    new QuarterlySubscriptionPlan()
                },
                {
                    Constants.BIANNUAL_PLAN,
                    new BiAnnualSubscriptionPlan()
                },
                {
                    Constants.ANNUAL_PLAN,
                    new AnnualSubscriptionPlan()
                },
            };
        }
    }
}
