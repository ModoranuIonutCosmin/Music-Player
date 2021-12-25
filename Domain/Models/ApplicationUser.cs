using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ApplicationUser : Common.BaseEntity
    {
        //[Index(IsUnique = true)]
        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(130)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
