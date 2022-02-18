using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Queries
{
    public class QueryUserByNameCommand : IRequest<ApplicationUser>
    {
        [Required]
        public string Username { get; }

        public QueryUserByNameCommand(string username)
        {
            Username = username;
        }
    }
}
