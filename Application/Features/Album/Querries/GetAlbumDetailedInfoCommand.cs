using System.ComponentModel.DataAnnotations;
using Domain.Models;
using MediatR;

namespace Application.Features.Metadata;

public class GetAlbumDetailedInfoCommand : IRequest<AlbumResponseDTO>
{
    [Required]
    public Guid AlbumId { get; set; }
}
