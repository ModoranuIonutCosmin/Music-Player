using Application.Interfaces;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1;

public class FavoritesRepository : Repository<UsersFavoriteAlbums>, IFavoritesRepository
{
    public FavoritesRepository(MediaPlayerContext context) : base(context)
    {
    }

    public async Task<bool> RemoveFavoriteForAlbum(Guid albumId, Guid userId)
    {
        var existingFavoriteEntry = await Context.UsersFavoriteAlbums
            .SingleOrDefaultAsync(fe => fe.ApplicationUserId.Equals(userId) &&
                                        fe.AlbumId.Equals(albumId));
        if (existingFavoriteEntry == null)
        {
            return false;
        }

        Context.UsersFavoriteAlbums.Remove(existingFavoriteEntry);

        await Context.SaveChangesAsync();

        return true;
    }

    public async Task<UsersFavoriteAlbums> AddFavoriteForAlbum(Guid albumId, Guid userId)
    {
        var existingFavoriteEntry = await Context.UsersFavoriteAlbums
            .SingleOrDefaultAsync(fe => fe.ApplicationUserId.Equals(userId) &&
                                        fe.AlbumId.Equals(albumId));
        if (existingFavoriteEntry != null)
        {
            return existingFavoriteEntry;
        }

        var favoriteEntry = new UsersFavoriteAlbums
        {
            AlbumId = albumId,
            ApplicationUserId = userId,
            DateSubmitted = DateTimeOffset.UtcNow,
        };

        await Context.UsersFavoriteAlbums.AddAsync(favoriteEntry);

        await Context.SaveChangesAsync();

        return favoriteEntry;
    }

    public async Task<UsersFavoriteAlbums> GetFavoriteEntryForUser(Guid userId, Guid albumId)
    {
        return await Context.UsersFavoriteAlbums
            .FirstOrDefaultAsync(fe => fe.AlbumId.Equals(albumId) &&
                                       fe.ApplicationUserId.Equals(userId));
    }

    public async Task<List<Album>> GetFavoriteAlbumsForUser(Guid userId)
    {
        return await Context.UsersFavoriteAlbums
            .Where(fe => fe.ApplicationUserId.Equals(userId))
            .Select(fe => fe.Album)
            .ToListAsync();
    }
}