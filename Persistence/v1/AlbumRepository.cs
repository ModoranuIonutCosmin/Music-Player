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
            return await context.Albums.Where(e => e.Id == albumId)
                .Include(e => e.Songs)
                    .ThenInclude(e => e.Artists)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Album>> GetAlbumsByNameSimilarity(string name)
        {
            return await context.Albums.Where(e => e.Name.ToLower().Contains(name))
                .ToListAsync();
        }
    }
}
