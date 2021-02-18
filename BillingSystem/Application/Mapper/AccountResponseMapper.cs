using Domain.Models;
using Recurly.Resources;


namespace Application.Mapper
{
    public static class AccountResponseMapper
    {
        public static AccountVM ToAccountResponse(this Account requestModel)
        {
            return new AccountVM
            {
                Id = requestModel.Id,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };

        }
    }
}
