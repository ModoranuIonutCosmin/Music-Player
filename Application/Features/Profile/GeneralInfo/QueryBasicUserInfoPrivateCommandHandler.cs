using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Profile.GeneralInfo;

public class QueryBasicUserInfoPrivateCommandHandler: IRequestHandler<QueryBasicUserInfoPrivateCommand, UserProfileModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public QueryBasicUserInfoPrivateCommandHandler(IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserProfileModel> Handle(QueryBasicUserInfoPrivateCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser userProfile = await _userRepository
            .GetByUsernameSubscriptionAsync(request.RequestingUser.UserName);

        return _mapper.Map<ApplicationUser, UserProfileModel>(userProfile);
    }
}