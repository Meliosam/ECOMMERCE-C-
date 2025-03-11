using MediatR;

namespace Core.Application.CasosUso.Produtos.Commands.Users.UpdateUsers
{
    public class UpdateUserCommand : IRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
