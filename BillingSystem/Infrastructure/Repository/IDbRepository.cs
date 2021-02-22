using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public interface IDbRepository<T>
    {
        void Insert(T record);
        void Delete(string id);
        List<T> GetAllRecords();       
        T GetRecordById(string id);
        void Update(T record, Guid id);
        T GetBy(Expression<Func<T, bool>> predicate);
    }
}
