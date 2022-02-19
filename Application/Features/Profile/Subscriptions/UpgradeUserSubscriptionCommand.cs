using Domain.Datamodels;
using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Profile.Subscriptions;

public class UpgradeUserSubscriptionCommand: IRequest<UserProfileModel>
{
    public ApplicationUser RequestingUser { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
}