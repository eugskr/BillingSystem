using Domain.Models;
using Recurly.Resources;


namespace Application.Mapper
{
    public static class AccountResponseMapper
    {
        public static AccountViewModel ToAccountResponse(this Account requestModel)
        {
            return new AccountViewModel
            {
                Id = requestModel.Id,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };

        }
    }
}
