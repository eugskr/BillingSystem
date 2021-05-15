using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IDbRepository<T>
    {
        Task Insert(T record);
        void Delete(string id);
        List<T> GetAllRecords();       
        T GetRecordById(string id);
        Task Update(T record, Guid id);
        T GetBy(Expression<Func<T, bool>> predicate);
        Task Upsert(T record, Guid id);
    }
}
