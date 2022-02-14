namespace Domain.Models;

public class NewsResponseDTO
{
    public List<NewsModel> News { get; set; }
    public long Total { get; set; }
}