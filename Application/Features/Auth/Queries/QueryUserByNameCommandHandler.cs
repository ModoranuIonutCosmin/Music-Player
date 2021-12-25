using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Queries;
public class QueryUserByNameCommandHandler : IRequestHandler<QueryUserByNameCommand, ApplicationUser>
{
    private readonly IUserRepository userRepository;

    public QueryUserByNameCommandHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<ApplicationUser> Handle(QueryUserByNameCommand request, CancellationToken cancellationToken)
    {
        return await userRepository.GetByUsernameAsync(request.Username);
    }
}
