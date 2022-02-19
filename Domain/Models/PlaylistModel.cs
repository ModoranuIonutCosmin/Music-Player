using Domain.Datamodels;

namespace Domain.Models;

public class PlaylistModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<SongModel> Songs { get; set; }
    public Visibility Visibility { get; set; }
}