using Domain.Common;

namespace Domain.Entities
{
    public class Storage : BaseEntity
    {
        public string SongId { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }
        public DateTimeOffset UrlExpiration { get; set; }
    }
}
