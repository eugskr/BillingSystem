using AutoMapper;
using Domain.Models;
using Recurly.Resources;
using Infrastructure.RecurlyProvider;

namespace Infrastructure.Automapper
{
    public class SubscriptionAutomapper: Profile
    {
        public SubscriptionAutomapper()
        {
            CreateMap<SubscriptionModel, SubscriptionCreate>()
                .ForMember(dest=> dest.CollectionMethod, 
                opt=> opt.MapFrom(src=> Constants.COLLECTION_METHOD))
                .ForPath(dest=> dest.Account.Code,
                    opt=> opt.MapFrom(src=> src.AccountCode));
        }
    }
}
