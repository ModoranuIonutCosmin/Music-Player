using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Song : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public List<Artist> Artists { get; set; }

    public Album Album { get; set; }

    public Storage Storage { get; set; }
}
