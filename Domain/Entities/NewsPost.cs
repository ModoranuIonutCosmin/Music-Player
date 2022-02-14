using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class NewsPost : BaseEntity
{
    [MaxLength(500)]
    public string Title { get; set; }
    [MaxLength(2000)]

    public string BannerImageUrl { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    [MaxLength(6000)]
    public string Body { get; set; }
}