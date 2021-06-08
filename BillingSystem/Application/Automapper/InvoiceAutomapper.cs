using AutoMapper;
using Domain.Responses;
using Domain.RepositoryModels;
using Recurly.Resources;

namespace Application.Automapper
{
    public class InvoiceAutomapper : Profile
    {
        public InvoiceAutomapper()
        {

            CreateMap<InvoiceCollection, InvoiceResponse>()
                .ForMember(dest => dest.AccountCode,
                    opt => opt.MapFrom(src => src.ChargeInvoice.Account.Code))                
                .ForMember(dest => dest.Currency,
                    opt => opt.MapFrom(src => src.ChargeInvoice.Currency))
                .ForMember(dest => dest.InvoiceId,
                    opt => opt.MapFrom(src => src.ChargeInvoice.Id))
                .ForMember(dest => dest.Items,
                    opt => opt.MapFrom(src => src.ChargeInvoice.LineItems.Data));
            CreateMap<LineItem, ChargeItem>();
            
        }
    }
}
