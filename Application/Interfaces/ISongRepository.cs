using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<List<Song>> GetSongByNameSimilarity(string name);
        Task<Song> SetSongDuration(Guid songId, long ticksLength);
    }
}
