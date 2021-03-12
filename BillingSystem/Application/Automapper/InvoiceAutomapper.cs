using AutoMapper;
using Domain.DTOs;
using Recurly.Resources;

namespace Application.Automapper
{
    public class InvoiceAutomapper : Profile
    {
        public InvoiceAutomapper()
        {

            CreateMap<InvoiceCollection, Domain.RepositoryModels.Invoice>()
                .ForMember(dest => dest.AccountCode,
                    opt => opt.MapFrom(src => src.ChargeInvoice.Account.Code))
                .ForMember(dest => dest.Ammount,
                    opt => opt.MapFrom(src => src.ChargeInvoice.Paid))
                .ForMember(dest => dest.Currency,
                    opt => opt.MapFrom(src => src.ChargeInvoice.Currency))
                .ForMember(dest => dest.InvoiceId,
                    opt => opt.MapFrom(src => src.ChargeInvoice.Id))
                .ForMember(s => s.Id, opt => opt.Ignore()); 

            CreateMap<Domain.RepositoryModels.Invoice, InvoiceDTO>();
        }
    }
}
