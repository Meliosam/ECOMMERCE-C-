using FluentValidation;

namespace Core.Application.CasosUso.Produtos.Commands.Create;

public class CriarProdutoCommandValidator : AbstractValidator<CriarProdutoCommand>
{
    public CriarProdutoCommandValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome do produto é obrigatório.");
        RuleFor(x => x.Preco).GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        RuleFor(x => x.Estoque).GreaterThanOrEqualTo(0).WithMessage("O estoque não pode ser negativo.");
        RuleFor(x => x.Descricao).NotEmpty().WithMessage("A descrição é obrigatória.");
    }
}
