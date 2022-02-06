using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Commands;

public class DeleteSongFromPlaylistCommand: IRequest<PlaylistModel>
{
    public Guid SongId { get; set; }
    public Guid PlaylistId { get; set; }
    public Guid RequestingUserId { get; set; }
}