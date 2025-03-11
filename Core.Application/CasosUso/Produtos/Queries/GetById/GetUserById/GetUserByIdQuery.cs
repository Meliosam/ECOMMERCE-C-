using MediatR;

namespace Core.Application.CasosUso.Produtos.Queries.GetById.GetUserById
{
    // Query que solicita um usuário pelo ID
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public string UserId { get; set; }

        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
