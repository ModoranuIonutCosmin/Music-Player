using Domain.Datamodels;

namespace Domain.Models
{
    public class SearchBarResult
    {
        public Guid Id { get; set; }

        public MediaFileType Type { get; set; }

        public string Name { get; set; }
    }
}
