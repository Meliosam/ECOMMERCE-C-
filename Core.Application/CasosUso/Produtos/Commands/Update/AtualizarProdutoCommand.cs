using MediatR;

namespace Core.Application.CasosUso.Produtos.Commands.Update;
public class AtualizarProdutoCommand : IRequest<bool>
{
    public string Id { get; set; } = string.Empty;  
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public string Descricao { get; set; } = string.Empty;
}

