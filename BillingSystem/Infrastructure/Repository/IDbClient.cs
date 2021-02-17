using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public interface IDbClient<T>
    {
        void AddAccount(T record);
        void DeleteAccount(string id);
        List<T> GetAccounts();
    }
}
