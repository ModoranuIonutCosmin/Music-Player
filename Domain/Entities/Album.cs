using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Album : BaseEntity
    {
        public ApplicationUser Owner { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Song> Songs { get; set; }
        public List<UsersFavoriteAlbums> UsersFavorites { get; set; }
    }
}
