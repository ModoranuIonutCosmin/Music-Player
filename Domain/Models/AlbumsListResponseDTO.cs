namespace Domain.Models;

public class AlbumsListResponseDTO
{
    public long Page { get; set; }
    public long Count { get; set; }
    public long ReturnedAlbumsCount { get; set; }
    public long TotalAlbumsCount { get; set; }
    public List<AlbumResponseDTO> Albums { get; set; }
}