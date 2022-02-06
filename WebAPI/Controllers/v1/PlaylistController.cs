using Application.Features.Playlist.Commands;
using Application.Features.Playlist.Querries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers.v1;

[ApiVersion("1.0")]
public class PlaylistController: BaseController
{
    public PlaylistController(IMediator mediator) : base(mediator)
    {
        
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> CreatePlaylist([FromBody] CreatePlaylistCommand createPlaylistCommand)
    {        
        ApplicationUser requestingUser = Request.HttpContext.Items["User"] as ApplicationUser;

        createPlaylistCommand.RequestingUserId = requestingUser.Id;
        
        return Created("playlist", await mediator.Send(createPlaylistCommand));
    }
    
    [HttpPatch("addSong")]
    [Authorize]
    public async Task<IActionResult> AddSongToPlaylist([FromBody] AddSongToPlaylistCommand addSongToPlaylistCommand)
    {
        ApplicationUser requestingUser = Request.HttpContext.Items["User"] as ApplicationUser;

        addSongToPlaylistCommand.RequestingUserId = requestingUser.Id;
        
        return Ok(await mediator.Send(addSongToPlaylistCommand));
    }
    
    [HttpDelete("deleteSong")]
    [Authorize]
    public async Task<IActionResult> DeleteSongFromPlaylist([FromBody] DeleteSongFromPlaylistCommand deleteSongFromPlaylistCommand)
    {
        ApplicationUser requestingUser = Request.HttpContext.Items["User"] as ApplicationUser;

        deleteSongFromPlaylistCommand.RequestingUserId = requestingUser.Id;
        return Ok(await mediator.Send(deleteSongFromPlaylistCommand));
    }
    
    
    [HttpGet("playlist")]
    [Authorize]
    public async Task<IActionResult> GetPlaylistRelatedData([FromQuery] QueryByPlaylistIdCommand queryByPlaylistIdCommand)
    {
        ApplicationUser requestingUser = Request.HttpContext.Items["User"] as ApplicationUser;

        queryByPlaylistIdCommand.RequestingUserId = requestingUser.Id;
        
        return Ok(await mediator.Send(queryByPlaylistIdCommand));
    }
    
    [HttpGet("myPlaylists")]
    [Authorize]
    public async Task<IActionResult> GetMyPlaylists()
    {
        QueryUsersPlaylistsCommand queryByPlaylistIdCommand = new QueryUsersPlaylistsCommand();
        
        ApplicationUser requestingUser = Request.HttpContext.Items["User"] as ApplicationUser;

        queryByPlaylistIdCommand.RequestingUserId = requestingUser.Id;
        
        return Ok(await mediator.Send(queryByPlaylistIdCommand));
    }
}