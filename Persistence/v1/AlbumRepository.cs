using System.Net.Mime;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(MediaPlayerContext context) : base(context)
        {
        }

        public async Task<List<Album>> GetAllAlbumsPaginatedOrderedByAddedDate(int page, int count, bool descending = true)
        {
            if (descending)
            {
                return await Context.Albums
                    .OrderByDescending(a => a.DateAdded)
                    .Skip(page * count)
                    .Take(count)
                    .Include(a => a.Artists)
                    .Include(a => a.Songs)
                    .AsNoTracking()
                    .ToListAsync();
            }

            return await Context.Albums
                .OrderBy(a => a.DateAdded)
                .Skip(page * count)
                .Take(count)
                .Include(a => a.Artists)
                .Include(a => a.Songs)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<List<Album>> GetAllAlbumsPaginatedOrderedByFavoritesVotes(int page, int count, bool descending = true)
        {
            if (descending)
            {
                return await Context.Albums.Skip(page * count)
                    .Take(count)
                    .OrderByDescending(a => a.UsersFavorites.Count)
                    .ThenByDescending(a => a.DateAdded)
                    .Include(a => a.Artists)
                    .Include(a => a.Songs)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();
            }
            
            return await Context.Albums.Skip(page * count)
                .Take(count)
                .OrderBy(a => a.UsersFavorites.Count)
                .ThenByDescending(a => a.DateAdded)
                .Include(a => a.Artists)
                .Include(a => a.Songs)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<long> GetAlbumsTotalCount()
        {
            return await Context.Albums.CountAsync();
        }

        public async Task<Album> GetAllAlbumInformationByAlbumId(Guid albumId)
        {
            return await Context.Albums.Where(e => e.Id == albumId)
                .Include(e => e.Songs)
                    .ThenInclude(e => e.Artists)
                .Include(e => e.Artists)
                .AsNoTracking()
                .AsSplitQuery()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Album>> GetAlbumsByNameSimilarity(string name, int count = int.MaxValue, int page = 0)
        {
            return await Context.Albums
                .Where(e => e.Name.ToLower().Contains(name) && e.Songs.Any())
                    .Include(a => a.Songs)
                .OrderBy(e => e.DateAdded)
                .Skip(page * count)
                .Take(count)
                .AsSplitQuery()
                .ToListAsync();
        }
    }
}
