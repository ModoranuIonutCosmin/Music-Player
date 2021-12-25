using Application.Features.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LoginController : BaseController
    {
        public LoginController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}
