using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Profile.GeneralInfo;

public class QueryBasicUserInfoPrivateCommandHandler: IRequestHandler<QueryBasicUserInfoPrivateCommand, UserProfileModel>
{
    private readonly IUserRepository _userRepository;
    private readonly ISubscriptionsService _subscriptionsService;
    private readonly IMapper _mapper;

    public QueryBasicUserInfoPrivateCommandHandler(IUserRepository userRepository,
        ISubscriptionsService subscriptionsService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _subscriptionsService = subscriptionsService;
        _mapper = mapper;
    }
    public async Task<UserProfileModel> Handle(QueryBasicUserInfoPrivateCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser userProfile = await _userRepository
            .GetByUsernameSubscriptionAsync(request.RequestingUser.UserName);
        var result = _mapper.Map<ApplicationUser, UserProfileModel>(userProfile);

        result.Subscription.UploadMinutesMax =
            _subscriptionsService.GetUploadMinutesForSubscription(result.Subscription.Type);
        
        return result;
    }
}