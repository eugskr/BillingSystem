using AutoMapper;
using Domain.Models;
using Recurly.Resources;

namespace Infrastructure.Automapper
{
    public class AccountAutomapper : Profile
    {
        public AccountAutomapper()
        {
            CreateMap<AccountModel, AccountCreate>();           
        }
    }
}
