using MediatR;
using static Infra.Data.Repositories.ProdutoRepository;

namespace Core.Application.CasosUso.Produtos.Commands.Delete
{
    public class DeletarProdutoCommandHandler : IRequestHandler<DeletarProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public DeletarProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(DeletarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(request.Id);

            if (produto == null)
            {
                // Produto não encontrado, retorne falso
                return false;
            }

            // Execute a exclusão
            await _produtoRepository.DeletarAsync(produto);

            // Indique que a operação foi bem-sucedida
            return true;
        }
    }

}
