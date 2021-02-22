using AutoMapper;
using Domain.DTOs;
using Recurly.Resources;

namespace Application.Automapper
{
    public class SubscriptionAutomapper:Profile
    {
        public SubscriptionAutomapper()
        {
            CreateMap<Subscription, SubscriptionDTO>()
                .ForMember(pts => pts.PlanCode, opt => opt.MapFrom(ps=>ps.Plan.Code));         
        }
    }
}
