using Application.Features.Favorites;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers.v1;

public class FavoritesController : BaseController
{
    public FavoritesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("checkFavorite")]
    [Authorize]
    public async Task<IActionResult> CheckFavoriteStatus(Guid albumId)
    {
        var userRequestingId = (Request.HttpContext.Items["User"] as
            Domain.Entities.ApplicationUser).Id;

        return Ok(await mediator.Send(new QueryAlbumFavoriteStatusCommand()
        {
            AlbumId = albumId,
            RequestingUserId = userRequestingId
        }));
    }


    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddAlbumToFavorites(Guid albumId)
    {
        var userRequestingId = (Request.HttpContext.Items["User"] as
            Domain.Entities.ApplicationUser).Id;

        return Created("favorite", await mediator.Send(new AddAlbumToFavoritesCommand()
        {
            AlbumId = albumId,
            RequestingUserId = userRequestingId
        }));
    }

    [HttpDelete("delete")]
    [Authorize]
    public async Task<IActionResult> UnfavoriteAlbum(Guid albumId)
    {
        var userRequestingId = (Request.HttpContext.Items["User"] as
            Domain.Entities.ApplicationUser).Id;

        return Ok(await mediator.Send(new DeleteAlbumFromFavoritesCommand
        {
            AlbumId = albumId,
            RequestingUserId = userRequestingId
        }));
    }
}