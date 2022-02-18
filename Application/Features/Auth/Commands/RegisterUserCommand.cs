using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Auth.Commands
{
    public class RegisterUserCommand : IRequest<RegisterResponseDTO>
    {
        [Required]
        [MaxLength(1000)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(1000)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(1000)]
        public string Password { get; set; }
    }
}
