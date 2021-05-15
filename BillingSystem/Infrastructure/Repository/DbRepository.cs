using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DbRepository<T> : IDbRepository<T> where T: class
    {
        private readonly IMongoCollection<T> _collection;

        public DbRepository()
        {    
            _collection = new MongoClient()
                .GetDatabase(Settings.Default.DatabaseName)
                .GetCollection<T>(typeof(T).Name);
        }
        public List<T> GetAllRecords() => _collection.Find(item => true).ToList();

        public T GetRecordById(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return _collection.Find(filter).First();
        }

        public async Task Insert(T record)
        {
            await _collection.InsertOneAsync(record);
        }

        public void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            _collection.DeleteOne(filter);
        }

        public async Task Update(T record, Guid id)
        {
            _collection.ReplaceOne(
                new BsonDocument("_id", id),
                record);
        }
        public async Task Upsert(T record, Guid id)
        {
            await _collection.ReplaceOneAsync(
                new BsonDocument("_id", id),
                record,
                new ReplaceOptions { IsUpsert = true });
        }
        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            return _collection.Find(predicate).FirstOrDefault();
        }
    }
}
