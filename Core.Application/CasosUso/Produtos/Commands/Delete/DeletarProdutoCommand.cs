using MediatR;

namespace Core.Application.CasosUso.Produtos.Commands.Delete
{
    public class DeletarProdutoCommand : IRequest <bool>
    {
        public DeletarProdutoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

}
