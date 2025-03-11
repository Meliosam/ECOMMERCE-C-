namespace Core.Application.CasosUso.Produtos.Commands.Update
{
    public class AtualizarProdutoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public required string Descricao { get; set; }
    }
}
