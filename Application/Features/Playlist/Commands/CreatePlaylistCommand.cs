using System.ComponentModel.DataAnnotations;
using Domain.Datamodels;
using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Commands;

public class CreatePlaylistCommand : IRequest<PlaylistCreationResponseDTO>
{
    [Required]
    [MaxLength(1000)]
    public string Name { get; set; }
    public Guid RequestingUserId { get; set; }
    [Required]
    public Visibility Visibility { get; set; }
}