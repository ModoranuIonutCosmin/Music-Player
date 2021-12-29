using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Song : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column(TypeName = "bigint")]
    public long Length { get; set; }

    [Required]
    public List<Artist> Artists { get; set; }

    public Album Album { get; set; }

    public Storage Storage { get; set; }
}
