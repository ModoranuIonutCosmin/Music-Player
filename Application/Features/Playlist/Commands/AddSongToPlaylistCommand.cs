using System.ComponentModel.DataAnnotations;
using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Commands;

public class AddSongToPlaylistCommand : IRequest<PlaylistModel>
{
    [Required]
    public Guid SongId { get; set; }
    [Required]
    public Guid PlaylistId { get; set; }
    public Guid RequestingUserId { get; set; }
}