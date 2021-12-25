namespace Domain.Models
{
    public class AlbumModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public List<SongModel> Songs { get; set; }
    }
}
