using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(MediaPlayerContext context) : base(context)
        {
            
        }
        public async Task<Playlist> LoadPlaylistsSongs(Guid playlistId)
        {
            return await Context.Playlists
                .Where(p => p.Id.Equals(playlistId))
                .Include(p => p.Songs)
                .SingleOrDefaultAsync();
        }

        public async Task AddSongToPlaylistAsync(Song song, Playlist playlist)
        {
            Playlist playlistEntity = await Context.Playlists
                .Where(p => p.Id == playlist.Id)
                .Include(e => e.Songs)
                .SingleOrDefaultAsync();

            playlistEntity.Songs.Add(song);

            await UpdateAsync(playlistEntity);
        }

        public async Task DeleteSongFromPlaylistAsync(Song song, Playlist playlist)
        {
            Playlist playlistEntity = await Context.Playlists
                .Where(p => p.Id == playlist.Id)
                    .Include(e => e.Songs)
                .SingleOrDefaultAsync();

            playlistEntity.Songs.Remove(song);

            await UpdateAsync(playlistEntity);
        }

        public async Task<List<Playlist>> GetUsersPlaylistsAsync(Guid userId)
        {
            ApplicationUser userEntity = await Context.Users
                .Where(u => u.Id.Equals(userId))
                    .Include(p => p.Playlists)
                    .ThenInclude(p => p.Songs)
                .SingleOrDefaultAsync();

            return userEntity.Playlists;
        }
    }
}
