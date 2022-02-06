using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(MediaPlayerContext context) : base(context)
        {
        }

        public async Task<Song> SetSongDuration(Guid songId, long ticksLength)
        {
            var song = await GetByIdAsync(songId);

            song.Length = ticksLength;

            await Context.SaveChangesAsync();

            return song;
        }

        public async Task<List<Song>> GetSongByNameSimilarity(string name, int count = int.MaxValue, int page = 0)
        {
            return await Context.Songs.Where(e => e.Name.ToLower().Contains(name))
                .OrderBy(e => e.DateAdded)
                .Skip(page * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Song> SetSongDateAdded(Guid songId, DateTimeOffset dateAdded)
        {
            var song = await GetByIdAsync(songId);

            song.DateAdded = dateAdded;

            await Context.SaveChangesAsync();

            return song;
        }

        public async Task<Song> LoadSongRelatedData(Guid songId)
        {
            return await Context.Songs
                .Include(e => e.Artists)
                .SingleOrDefaultAsync(e => e.Id.Equals(songId));

        }
    }
}
