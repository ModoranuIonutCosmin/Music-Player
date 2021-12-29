using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1;

public class MediaSearchController : ControllerBase
{
    private readonly IMediator mediator;

    public MediaSearchController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> QueryThroughAlbumsAndSongs(string query)
    {
        return Ok(await mediator.Send(new SearchMediaCommand
        {
            Query = query,
        }));
    }
}
