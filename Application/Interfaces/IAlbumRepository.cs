using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<List<Album>> GetAlbumsByNameSimilarity(string name, int count = int.MaxValue, int page = 0);
        Task<Album> GetAllAlbumInformationByAlbumId(Guid albumId);
    }
}
