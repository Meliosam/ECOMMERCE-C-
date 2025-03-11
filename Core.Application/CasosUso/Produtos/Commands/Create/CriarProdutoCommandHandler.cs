using MediatR;
using Infra.Data.Repositories;
using Core.Domain.Entities;

namespace Core.Application.CasosUso.Produtos.Commands.Create;

public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Guid>
{
    private readonly ProdutoRepository _produtoRepository;

    public CriarProdutoCommandHandler(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Guid> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
    {
        var novoProduto = new Produto
        {
            Nome = request.Nome,
            Preco = request.Preco,
            Estoque = request.Estoque,
            Descricao = request.Descricao
        };
        await _produtoRepository.CreateAsync(novoProduto);
        return novoProduto.Id; // Retorna o ID do produto criado
    }
}
