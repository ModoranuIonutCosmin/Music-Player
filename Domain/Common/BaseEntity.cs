using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
