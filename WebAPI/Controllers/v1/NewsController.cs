using Application.Features.Auth.Commands;
using Application.Features.News;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class NewsController : BaseController
    {
        public NewsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetNews([FromQuery] QueryNewsCommand command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}
