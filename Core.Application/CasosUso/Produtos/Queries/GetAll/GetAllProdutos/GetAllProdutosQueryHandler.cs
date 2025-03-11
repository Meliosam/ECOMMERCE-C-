namespace Core.Application.CasosUso.Produtos.Queries.GetAll.GetAllProdutos;

using AutoMapper;
using Core.Application.CasosUso;
using Infra.Data.Repositories;
using MediatR;

public class GetAllProdutosQueryHandler : IRequestHandler<GetAllProdutosQuery, List<ProdutoDTO>>
{
    private readonly ProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public GetAllProdutosQueryHandler(ProdutoRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); // Garantindo que o IMapper não seja null
    }

    public async Task<List<ProdutoDTO>> Handle(GetAllProdutosQuery request, CancellationToken cancellationToken)
    {
        // Obter todos os produtos do repositório
        var produtos = await _produtoRepository.GetAllAsync();

        // Mapear os produtos para o DTO
        var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);

        return produtosDto;
    }
}
