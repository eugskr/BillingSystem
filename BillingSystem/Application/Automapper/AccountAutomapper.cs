using AutoMapper;
using Domain.Responses;
using Domain.RepositoryModels;
using Recurly.Resources;

namespace Application.Automapper
{
    public class AccountAutomapper: Profile
    {
        public AccountAutomapper()
        {
            CreateMap <Recurly.Resources.Account, Domain.RepositoryModels.Account> ()
                .ForMember(s=>s.Id, opt=>opt.Ignore());
            CreateMap<Domain.RepositoryModels.Account, AccountResponse>();
            CreateMap<Domain.Models.AccountCreate, AccountCreate>();
        }
    }
}
