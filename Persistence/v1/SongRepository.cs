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

            await context.SaveChangesAsync();

            return song;
        }

        public async Task<List<Song>> GetSongByNameSimilarity(string name)
        {
            return await context.Songs.Where(e => e.Name.ToLower().Contains(name))
                .ToListAsync();
        }
    }
}
