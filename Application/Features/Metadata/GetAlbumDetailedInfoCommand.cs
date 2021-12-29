using Domain.Models;
using MediatR;

namespace Application.Features.Metadata;

public class GetAlbumDetailedInfoCommand : IRequest<AlbumResponseDTO>
{
    public Guid AlbumId { get; set; }
}
