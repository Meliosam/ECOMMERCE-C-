using Core.Application.CasosUso.Produtos.Commands.Users.Commands;
using Core.Application.CasosUso.Produtos.Commands.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.CasosUso.Usuarios.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Senha);

            if (result.Succeeded)
            {
                return new CreateUserResponse
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Message = "Usuário criado com sucesso!"
                };
            }
            else
            {
                return new CreateUserResponse
                {
                    UserId = null,
                    Email = request.Email,
                    Message = "Erro ao criar o usuário: " + string.Join(", ", result.Errors.Select(e => e.Description))
                };
            }
        }
    }
}
