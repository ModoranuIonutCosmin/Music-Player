using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Datamodels;

namespace Domain.Entities
{
    public class Playlist : BaseEntity
    {
        public ApplicationUser User { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public Visibility Visibility { get; set; }
    }
}
