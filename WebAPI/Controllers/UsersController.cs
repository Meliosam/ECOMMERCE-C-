using Core.Application.CasosUso.Produtos.Commands.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();

        }
    }
}
