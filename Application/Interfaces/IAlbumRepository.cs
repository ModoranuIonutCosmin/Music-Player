using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<List<Album>> GetAlbumsByNameSimilarity(string name, int count = int.MaxValue, int page = 0);
        Task<Album> GetAllAlbumInformationByAlbumId(Guid albumId);
        Task<List<Album>> GetAllAlbumsPaginatedOrderedByAddedDate(int page, int count, bool descending = true);
        Task<long> GetAlbumsTotalCount();
        Task<List<Album>> GetAllAlbumsPaginatedOrderedByFavoritesVotes(int page, int count, bool descending = true);
    }
}
