using AutoMapper;
using Recurly.Resources;
using Infrastructure.RecurlyProvider;

namespace Infrastructure.Automapper
{
    public class SubscriptionAutomapper: Profile
    {
        public SubscriptionAutomapper()
        {
            CreateMap<Domain.Models.SubscriptionCreate, SubscriptionCreate>()
                .ForMember(dest=> dest.CollectionMethod, 
                opt=> opt.MapFrom(src=> Constants.MANUAL))
                .ForPath(dest=> dest.Account.Code,
                    opt=> opt.MapFrom(src=> src.AccountCode));            
        }
    }
}
