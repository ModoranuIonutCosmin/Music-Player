using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<List<Album>> GetAlbumsByNameSimilarity(string name);
        Task<Album> GetAllAlbumInformationByAlbumId(Guid albumId);
    }
}
