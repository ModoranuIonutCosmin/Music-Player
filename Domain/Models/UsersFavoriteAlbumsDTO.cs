namespace Domain.Models;

public class UsersFavoriteAlbumsDTO
{
    public bool IsFavorite { get; set; } = true;
    public Guid AlbumId { get; set; }
    public DateTimeOffset DateSubmitted { get; set; }
}