using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Artist : BaseEntity
    {
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ArtistName { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }

        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Artist model &&
                   ArtistName.Equals(model.ArtistName, StringComparison.InvariantCultureIgnoreCase) &&
                   FirstName.Equals(model.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                   LastName.Equals(model.LastName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return ArtistName.GetHashCode() ^ FirstName.GetHashCode() ^ LastName.GetHashCode();
        }
    }
}
