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
                    "monthly_plan",
                    new MonthlySubscriptionPlan()
                },
                {
                    "quarterly_plan",
                    new QuarterlySubscriptionPlan()
                },
                {
                    "biannual_plan",
                    new BiAnnualSubscriptionPlan()
                },
                {
                    "annual_plan",
                    new AnnualSubscriptionPlan()
                },
            };
        }
    }
}
