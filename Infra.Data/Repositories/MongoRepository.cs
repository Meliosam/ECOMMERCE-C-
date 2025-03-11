using MongoDB.Driver;
using MongoDB.Bson;

namespace Infra.Data
{
    public class MongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoClient mongoClient, string databaseName, string collectionName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _collection.Find(new BsonDocument()).ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();

        public async Task CreateAsync(T document) =>
            await _collection.InsertOneAsync(document);

        public async Task UpdateAsync(string id, T document) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), document);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }
}
