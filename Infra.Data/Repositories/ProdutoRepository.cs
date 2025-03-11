using Core.Domain.Entities;
using MongoDB.Driver;

namespace Infra.Data.Repositories
{
    public class ProdutoRepository
    {
        private readonly IMongoCollection<Produto> _collection;

        public ProdutoRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("EcommerceDB");
            _collection = database.GetCollection<Produto>("Produtos");
        }

        // Obter todos os produtos
        public async Task<List<Produto>> GetAllAsync() =>
            await _collection.Find(Builders<Produto>.Filter.Empty).ToListAsync();

        // Obter um produto por ID
        public async Task<Produto> GetByIdAsync(Guid id)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }


        // Adicionar um novo produto
        public async Task CreateAsync(Produto produto) =>
            await _collection.InsertOneAsync(produto);

        // Atualizar um produto existente
        public async Task UpdateAsync(Guid id, Produto produto)
        {
            // Verificação para garantir que o id corresponde ao tipo Guid
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            var update = Builders<Produto>.Update
                            .Set(p => p.Nome, produto.Nome)
                            .Set(p => p.Preco, produto.Preco)
                            .Set(p => p.Descricao, produto.Descricao)
                            .Set(p => p.Estoque, produto.Estoque);

            var result = await _collection.UpdateOneAsync(filter, update);

            if (result.ModifiedCount == 0)
            {
                throw new KeyNotFoundException("Produto não encontrado para atualização.");
            }
        }
        public interface IProdutoRepository
        {
            Task<Produto?> ObterPorIdAsync(Guid id);
            Task<bool> DeletarAsync(Produto produto);
        }



        // Deletar um produto
        public async Task DeleteAsync(Guid id)
        {
            var result = await _collection.DeleteOneAsync(Builders<Produto>.Filter.Eq(p => p.Id, id));

            if (result.DeletedCount == 0)
            {
                throw new KeyNotFoundException("Produto não encontrado para exclusão.");
            }
        }
    }
}

























//using Core.Domain.Entities;
//using MongoDB.Driver;
//using MongoDB.Bson;

//namespace Infra.Data.Repositories
//{
//    public class ProdutoRepository
//    {
//        private readonly IMongoCollection<Produto> _collection;

//        public ProdutoRepository(IMongoClient mongoClient)
//        {
//            var database = mongoClient.GetDatabase("EcommerceDB");
//            _collection = database.GetCollection<Produto>("Produtos");
//        }

//        // Obter todos os produtos
//        public async Task<List<Produto>> GetAllAsync() =>
//            await _collection.Find(Builders<Produto>.Filter.Empty).ToListAsync();

//        // Obter um produto por ID
//        public async Task<Produto?> GetByIdAsync(ObjectId id)
//        {
//            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
//        }

//        // Adicionar um novo produto
//        public async Task CreateAsync(Produto produto) =>
//            await _collection.InsertOneAsync(produto);

//        // Atualizar um produto existente
//        public async Task UpdateAsync(string id, Produto produto)
//        {
//            if (!ObjectId.TryParse(id, out var objectId))
//            {
//                throw new FormatException("O ID fornecido não é válido.");
//            }

//            await _collection.ReplaceOneAsync(Builders<Produto>.Filter.Eq(p => p.Id, objectId), produto);
//        }

//        // Deletar um produto
//        public async Task DeleteAsync(ObjectId id)
//        {
//            await _collection.DeleteOneAsync(Builders<Produto>.Filter.Eq(p => p.Id, id));
//        }
//    }
//}
