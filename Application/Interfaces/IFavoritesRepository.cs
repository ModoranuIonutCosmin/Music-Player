using Domain.Entities;

namespace Application.Interfaces;

public interface IFavoritesRepository : IRepository<UsersFavoriteAlbums>
{
    Task<UsersFavoriteAlbums> AddFavoriteForAlbum(Guid albumId, Guid userId);
    Task<bool> RemoveFavoriteForAlbum(Guid albumId, Guid userId);
    Task<UsersFavoriteAlbums> GetFavoriteEntryForUser(Guid userId, Guid albumId);
}