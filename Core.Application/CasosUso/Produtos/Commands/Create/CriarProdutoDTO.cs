namespace Core.Application.CasosUso.Produtos.Commands.Create
{
    public class CriarProdutoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }    
        public required string Descricao {get; set;}
    }
}





