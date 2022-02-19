namespace Domain.Models
{
    public class SearchBarResultsResponse
    {
        public string Query { get; set; }
        public SearchBarResult Results { get; set; }
        public int AlbumEntries => Results.Albums.Count;
        public int SongEntries => Results.Songs.Count;
    }
}
