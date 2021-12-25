using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.v1
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(MediaPlayerContext context) : base(context)
        {
        }
    }
}
