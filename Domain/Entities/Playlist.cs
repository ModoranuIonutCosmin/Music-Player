using Domain.Common;

namespace Domain.Entities
{
    public class Playlist : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public List<Song> Songs { get; set; }
    }
}
