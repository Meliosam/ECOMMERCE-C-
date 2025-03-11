using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.CasosUso.Produtos.Commands.Users.UpdateUsers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UpdateUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            user.UserName = request.UserName;
            user.Email = request.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return Unit.Value;
        }

        Task IRequestHandler<UpdateUserCommand>.Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
