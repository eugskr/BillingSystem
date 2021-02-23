using AutoMapper;
using Domain.DTOs;
using Domain.Models;
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
            CreateMap<Domain.RepositoryModels.Account, AccountDTO>();
            CreateMap<AccountModel, AccountCreate>();
        }
    }
}
