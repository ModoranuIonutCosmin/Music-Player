namespace Domain.Models
{
    public class SongModel
    {
        public Guid Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public long Length { get; set; }
        public List<ArtistModel> Artists { get; set; }
    }
}
