using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<Playlist> LoadPlaylistsSongs(Guid playlistId);
        Task AddSongToPlaylistAsync(Song song, Playlist playlist);
        Task DeleteSongFromPlaylistAsync(Song song, Playlist playlist);
        Task<List<Playlist>> GetUsersPlaylistsAsync(Guid userId);
    }
}
