using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1
{
    public class StorageInfoRepository : Repository<Storage>, IStorageInfoRepository
    {
        public StorageInfoRepository(MediaPlayerContext context) : base(context)
        {

        }

        public async Task UpdateFileUrl(Guid storageId, string url, DateTimeOffset expiryDate)
        {
            var storageInfo = await GetByIdAsync(storageId);

            storageInfo.Url = url;
            storageInfo.UrlExpiration = expiryDate;

            await Context.SaveChangesAsync();
        }

        public async Task<Storage> FindBySongId(Guid songId)
        {
            return await Context.StorageInfo.SingleOrDefaultAsync(e => e.SongId.Equals(songId));
        }
    }
}
