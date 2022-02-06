namespace Domain.Models
{
    public class SongModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Duration { get; set; }
        public List<ArtistModel> Artists { get; set; }
    }
}
