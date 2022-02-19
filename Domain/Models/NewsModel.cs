namespace Domain.Models;

public class NewsModel
{
    public string Title { get; set; }
    public string BannerImageUrl { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public string Body { get; set; }
}