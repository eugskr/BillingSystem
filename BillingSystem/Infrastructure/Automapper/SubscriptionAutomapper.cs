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
                opt=> opt.MapFrom(src=> Constants.MANUAL))
                .ForPath(dest=> dest.Account.Code,
                    opt=> opt.MapFrom(src=> src.AccountCode));

            CreateMap<InvoiceModel, PurchaseCreate>()
                .ForMember(dest => dest.Currency,
                    opt => opt.MapFrom(src => Constants.UAH))
                .ForMember(dest => dest.CollectionMethod,
                    opt => opt.MapFrom(src => Constants.AUTOMATIC))
                .ForPath(dest => dest.Account,
                    opt => opt.MapFrom(src => new AccountPurchase
                    {
                        Code = src.AccountCode
                    }))
                .ForPath(dest => dest.LineItems,
                    opt => opt.MapFrom(src => new LineItemCreate
                    {
                        Type = Constants.CHARGE,
                        UnitAmount = src.UnitAmmount,
                        Currency = Constants.UAH
                    }));
        }
    }
}
