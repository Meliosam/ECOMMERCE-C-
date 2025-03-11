using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Repositories;
using MediatR;

namespace Core.Application.CasosUso.Produtos.Commands.Update
{
    public class AtualizarProdutoCommandHandler : IRequestHandler<AtualizarProdutoCommand, bool>
    {
        private readonly ProdutoRepository _produtoRepository;

        public AtualizarProdutoCommandHandler(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            // Verifique se o produto existe no repositório
            var produto = await _produtoRepository.GetByIdAsync(Guid.Parse(request.Id));

            if (produto == null)
            {
                return false; // Produto não encontrado
            }

            // Atualize as propriedades do produto
            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Estoque = request.Estoque;
            produto.Descricao = request.Descricao;

            // Salve as alterações
            await _produtoRepository.UpdateAsync(Guid.Parse(request.Id), produto);

            return true; // Atualização concluída com sucesso
        }
    }
}