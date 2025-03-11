namespace Core.Application.CasosUso.Produtos.Queries.GetAll.GetProdutoById
{
    public class GetAllProdutosDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Estoque { get; set; }

        // Propriedade opcional, dependendo do que você quer expor no DTO
        public DateTime DataCriacao { get; set; }
    }
}
