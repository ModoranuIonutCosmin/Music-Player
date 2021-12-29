using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Storage : BaseEntity
    {
        public Guid SongId { get; set; }
        [MaxLength(512)]
        public string Path { get; set; }
        public long Size { get; set; }
        [MaxLength(512)]
        public string Url { get; set; }
        
        [MaxLength(20)]
        public string Extension { get; set; }
        public DateTimeOffset UrlExpiration { get; set; }
    }
}
