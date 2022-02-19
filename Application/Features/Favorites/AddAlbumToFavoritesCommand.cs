using Domain.Entities;
using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Favorites;

public class AddAlbumToFavoritesCommand: IRequest<UsersFavoriteAlbumsDTO>
{
    public Guid RequestingUserId { get; set; }
    public Guid AlbumId { get; set; }
}