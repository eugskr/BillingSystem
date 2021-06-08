using AutoMapper;
using Recurly.Resources;

namespace Infrastructure.Automapper
{
    public class AccountAutomapper : Profile
    {
        public AccountAutomapper()
        {
            CreateMap<Domain.Models.AccountCreate, AccountCreate>();           
        }
    }
}
