using Domain.Common;

namespace Domain.Entities;

public class NewsPost : BaseEntity
{
    public string Title { get; set; }
    public string BannerImageUrl { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public string Body { get; set; }
}