using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Queries
{
    public class QueryUserByNameCommand : IRequest<ApplicationUser>
    {
        public string Username { get; set; }

        public QueryUserByNameCommand(string username)
        {
            Username = username;
        }
    }
}
