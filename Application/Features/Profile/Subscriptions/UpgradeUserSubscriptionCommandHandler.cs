using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Datamodels;
using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Profile.Subscriptions;

public class UpgradeUserSubscriptionCommandHandler: IRequestHandler<UpgradeUserSubscriptionCommand, UserProfileModel>
{
    private readonly ISubscriptionsService _subscriptionsService;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpgradeUserSubscriptionCommandHandler(ISubscriptionsService subscriptionsService,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _subscriptionsService = subscriptionsService;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserProfileModel> Handle(UpgradeUserSubscriptionCommand request, CancellationToken cancellationToken)
    {
        if (request.RequestingUser == null)
        {
            throw new UnauthorizedAccessException("User isn't allowed to upgrade his subscription");
        }

        ApplicationUser userRequesting = await _userRepository
            .GetByUsernameSubscriptionAsync(request.RequestingUser.UserName);
        
        _subscriptionsService.GrantSubscriptionPlan(userRequesting.Id, request.SubscriptionType, 30);
        
        return _mapper.Map<ApplicationUser, UserProfileModel>(userRequesting);
    }
}