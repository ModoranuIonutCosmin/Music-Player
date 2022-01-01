namespace Domain.Models
{
    public class SongResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CoverImageUrl { get; set; }
        public long Length { get; set; }
        public List<ArtistModel> Artists { get; set; }
    }
}
