using MediatR;

namespace Core.Application.CasosUso.Produtos.Commands.Create;
public class CriarProdutoCommand : IRequest<Guid>
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public required string Descricao { get; set; }
    public int Estoque { get; set; }
}
