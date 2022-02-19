using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1;

public class MediaSearchController : BaseController
{
    private readonly IMediator mediator;

    public MediaSearchController(IMediator mediator) : base(mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> QueryThroughAlbumsAndSongs([FromQuery]SearchMediaCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}
