using Domain.Datamodels;

namespace Domain.Models
{
    public class SearchBarResult
    {
        public List<SongResponseDTO> Songs { get; set; }
        public List<AlbumResponseDTO> Albums { get; set; }
    }
}
