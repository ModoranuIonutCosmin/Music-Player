using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<List<Song>> GetSongByNameSimilarity(string name, int count = int.MaxValue, int page = 0);
        Task<Song> SetSongDuration(Guid songId, long ticksLength);
        Task<Song> SetSongDateAdded(Guid songId, DateTimeOffset dateAdded);
        Task<Song> LoadSongRelatedData(Guid songId);
    }
}
