using Core.Application.CasosUso.Produtos.Queries.GetById.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.CasosUso.Produtos.Queries.GetAll.GetAllUsers
{
    // Handler responsável por processar a query
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetAllUsersQueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList(); // Obtém todos os usuários

            // Converte os usuários para o formato DTO
            return users.Select(user => new UserDTO
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email
            }).ToList();
        }
    }
}
