using MediatR;


namespace Core.Application.CasosUso.Produtos.Commands.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
