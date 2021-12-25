using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.v1
{
    public class StorageInfoRepository : Repository<Storage>, IStorageInfoRepository
    {
        public StorageInfoRepository(MediaPlayerContext context) : base(context)
        {

        }
    }
}
