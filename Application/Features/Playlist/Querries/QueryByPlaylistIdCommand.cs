using System.ComponentModel.DataAnnotations;
using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Querries;

public class QueryByPlaylistIdCommand : IRequest<PlaylistModel>
{

    [Required]
    public Guid PlaylistId { get; set; }
    public Guid RequestingUserId { get; set; }
}