namespace Infra.Data.Persistence
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DataBaseName { get; set; } = string.Empty;
    }
}
// configurando o DB para o projeto