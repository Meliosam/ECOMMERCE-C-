using MediatR;

namespace Core.Application.CasosUso.Produtos.Queries.GetAll.GetProdutoById
{
    public class GetProdutoByIdQuery : IRequest<ProdutoDTO>
    {
        public Guid ProdutoId { get; }

        public GetProdutoByIdQuery(Guid produtoId)
        {
            ProdutoId = produtoId;
        }
    }
}