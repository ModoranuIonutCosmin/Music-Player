using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Querries;

public class QueryUsersPlaylistsCommand : IRequest<PlaylistsResponseDTO>
{
    public Guid RequestingUserId { get; set; }
}