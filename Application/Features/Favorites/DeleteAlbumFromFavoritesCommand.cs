using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Favorites;

public class DeleteAlbumFromFavoritesCommand: IRequest
{
    public Guid RequestingUserId { get; set; }
    [Required]
    public Guid AlbumId { get; set; }
}