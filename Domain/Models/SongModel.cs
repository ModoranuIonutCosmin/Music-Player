namespace Domain.Models
{
    public class SongModel
    {
        public string Name { get; set; }
        public List<ArtistModel> Artists { get; set; }
    }
}
