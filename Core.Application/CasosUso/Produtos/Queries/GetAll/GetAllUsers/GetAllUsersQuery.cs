using Core.Application.CasosUso.Produtos.Queries.GetById.GetUserById;
using MediatR;

namespace Core.Application.CasosUso.Produtos.Queries.GetAll.GetAllUsers
{
    // Query que solicita a lista de todos os usuários
    public class GetAllUsersQuery : IRequest<List<UserDTO>>
    {
    }
}
