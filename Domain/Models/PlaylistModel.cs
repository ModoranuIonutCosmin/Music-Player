using Domain.Datamodels;

namespace Domain.Models;

public class PlaylistModel
{
    public string Name { get; set; }
    public List<SongModel> Songs { get; set; }
    public Visibility Visibility { get; set; }
}