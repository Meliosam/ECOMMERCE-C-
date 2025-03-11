using MongoDB.Driver;

namespace Infra.Data.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoClient _mongoClient;

        public MongoDbContext(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = _mongoClient.GetDatabase("EcommerceDB");
            return database.GetCollection<T>(collectionName);
        }
    }
}
