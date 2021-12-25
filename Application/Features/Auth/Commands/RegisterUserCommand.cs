using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Auth.Commands
{
    public class RegisterUserCommand : IRequest<RegisterResponseDTO>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
