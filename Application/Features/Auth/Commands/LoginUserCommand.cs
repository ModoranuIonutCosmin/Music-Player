using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Auth.Commands
{
    public class LoginUserCommand : IRequest<LoginResponseDTO>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
