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
            return await Context.Albums.Where(e => e.Name.ToLower().Contains(name))
                .OrderBy(e => e.DateAdded)
                .Skip(page * count)
                .Take(count)
                .ToListAsync();
        }
    }
}
