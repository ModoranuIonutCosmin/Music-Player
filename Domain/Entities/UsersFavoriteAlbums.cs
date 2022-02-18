using Domain.Common;

namespace Domain.Entities;

public class UsersFavoriteAlbums: BaseEntity
{
    public ApplicationUser ApplicationUser { get; set; }
    public Guid ApplicationUserId { get; set; }
    public Guid AlbumId { get; set; }
    public Album Album { get; set; }
    public DateTimeOffset DateSubmitted { get; set; }
}