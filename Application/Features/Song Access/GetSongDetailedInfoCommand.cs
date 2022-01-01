using Domain.Models;
using MediatR;

namespace Application.Features.Song_Access;

public class GetSongDetailedInfoCommand : IRequest<SongResponseDTO>
{
    public Guid SongId { get; set; }
}
