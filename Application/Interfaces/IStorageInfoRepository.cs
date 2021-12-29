using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStorageInfoRepository : IRepository<Storage>
    {
        Task<Storage> FindBySongId(Guid songId);
        public Task UpdateFileUrl(Guid storageId, string url, DateTimeOffset expiryDate);
    }
}
