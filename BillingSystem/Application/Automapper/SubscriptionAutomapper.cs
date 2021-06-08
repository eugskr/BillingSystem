using AutoMapper;
using Domain.Responses;
using Recurly.Resources;

namespace Application.Automapper
{
    public class SubscriptionAutomapper:Profile
    {
        public SubscriptionAutomapper()
        {
            CreateMap<Subscription, SubscriptionResponse>()
                .ForMember(pts => pts.PlanCode, opt => opt.MapFrom(ps=>ps.Plan.Code));         
        }
    }
}
