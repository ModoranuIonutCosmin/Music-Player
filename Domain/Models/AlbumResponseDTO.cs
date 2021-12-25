namespace Domain.Models
{
    public class AlbumResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public List<ArtistModel> Artists { get; set; }
        public List<SongResponseDTO> Songs { get; set; }
    }
}
