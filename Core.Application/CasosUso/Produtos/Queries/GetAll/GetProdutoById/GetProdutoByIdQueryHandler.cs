using MediatR;
using Infra.Data.Repositories;
using AutoMapper;


namespace Core.Application.CasosUso.Produtos.Queries.GetAll.GetProdutoById
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, ProdutoDTO>
    {
        private readonly ProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public GetProdutoByIdQueryHandler(ProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            // Buscar o produto pelo ID
            var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);

            if (produto == null)
            {
                // Retorne null ou lance uma exceção, caso o produto não seja encontrado
                return null;
            }

            // Mapeando a entidade Produto para ProdutoDTO
            return _mapper.Map<ProdutoDTO>(produto);
        }
    }
}


