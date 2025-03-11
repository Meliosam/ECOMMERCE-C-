using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Domain.Entities;
using Core.Application.CasosUso.Produtos.Commands.Create;
using Core.Application.CasosUso.Produtos.Commands.Update;
using Core.Application.CasosUso.Produtos.Commands.Delete;
using Core.Application.CasosUso.Produtos.Queries.GetAll.GetAllProdutos;
using Core.Application.CasosUso.Produtos.Queries.GetAll.GetProdutoById;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // Endpoint para listar todos os produtos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProdutosQuery();
            var produtos = await _mediator.Send(query);

            if (produtos == null || produtos.Count == 0)
            {
                return NotFound("Não existe produto na lista.");
            }

            return Ok(produtos);
        }

        // Endpoint para obter um produto por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProdutoByIdQuery (id);
            var produto = await _mediator.Send(query);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produto);
        }

        // Endpoint para criar um novo produto
        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoDTO criarProdutoDTO)
        {
            var command = new CriarProdutoCommand
            {
                Nome = criarProdutoDTO.Nome,
                Preco = criarProdutoDTO.Preco,
                Estoque = criarProdutoDTO.Estoque,
                Descricao = criarProdutoDTO.Descricao
            };
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id });
        }

       // Endpoint para atualizar um produto existente
       [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Produto produto)
        {
            var command = new AtualizarProdutoCommand
            {
                Id = id,
                Nome = produto.Nome!,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            };

            var sucesso = await _mediator.Send(command);

            if (!sucesso)
            {
                return NotFound("Produto não encontrado.");
            }

            return NoContent();
        }

        //  Endpoint para deletar um produto
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletarProdutoCommand(id);
            _ = await _mediator.Send(command);


            return Ok("Sucesso");
        }
    }
}

































