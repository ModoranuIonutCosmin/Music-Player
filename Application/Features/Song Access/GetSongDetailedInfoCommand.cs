using System.ComponentModel.DataAnnotations;
using Domain.Models;
using MediatR;

namespace Application.Features.Song_Access;

public class GetSongDetailedInfoCommand : IRequest<SongResponseDTO>
{
    [Required]
    public Guid SongId { get; set; }
}
