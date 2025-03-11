using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.CasosUso.Produtos.Queries.GetById.GetUserById
{
    // Handler responsável por processar a query
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetUserByIdQueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("Usuário não encontrado."); // Exceção simples, pode ser substituída por uma customizada

            // Retorna o usuário no formato DTO
            return new UserDTO
            {
                UserId = user.Id,
                UserName = string.Empty,
                Email = string.Empty
            };
        }
    }
}
