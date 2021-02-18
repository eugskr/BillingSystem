using MongoDB.Driver;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public class DbClient<T> : IDbClient<T> where T: class
    {
        private readonly IMongoCollection<T> _collection;

        public DbClient()
        {
            var client = new MongoClient();
            var db = client.GetDatabase(Settings.Default.DatabaseName);
            _collection = db.GetCollection<T>("Accounts");
        }
        public List<T> GetAccounts() => _collection.Find(item => true).ToList();

        public void AddAccount(T viewModel)
        {
            _collection.InsertOne(viewModel);
        }

        public void DeleteAccount(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            _collection.DeleteOne(filter);
        }
    }
}
