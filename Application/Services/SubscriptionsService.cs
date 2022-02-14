using Application.Interfaces;
using Domain.Datamodels;
using Domain.Entities;

namespace Application.Services;

public class SubscriptionsService : ISubscriptionsService
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public SubscriptionsService(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public void GrantSubscriptionPlan(Guid userId, SubscriptionType subscriptionType,
        int dayCount = Int32.MaxValue)
    {
        this._subscriptionsRepository.SetUserSubscription(userId,
            new Subscription()
            {
                Type = subscriptionType,
                ExpiryDate = DateTimeOffset.UtcNow.AddDays(dayCount),
                PurchaseDate = DateTimeOffset.UtcNow,
                UploadMinutesUsed = 0,
            }).Wait();
    }

    public async Task DeductUserMinutes(Guid userId, decimal uploadMinutesCount)
    {
        await this._subscriptionsRepository.DeductUserMinutes(userId, uploadMinutesCount);
    }
    
    public bool UserHasEnoughMinutesForUpload(Guid userId, decimal uploadMinutesCount)
    {
        Subscription userSubscription = GetUserSubscription(userId).Result;

        if (userSubscription == null)
        {
            return false;
        }

        var subscriptionType = userSubscription.ExpiryDate < DateTimeOffset.UtcNow
            ? userSubscription.Type
            : SubscriptionType.FREE;
        
        decimal subscriptionMax = GetUploadMinutesForSubscription(subscriptionType);
        decimal usedMinutes = userSubscription.UploadMinutesUsed;

        return (subscriptionMax - uploadMinutesCount - usedMinutes) >= 0;
    }

    private async Task<Subscription> GetUserSubscription(Guid userId)
    {
        return await _subscriptionsRepository.GetUserSubscription(userId);
    }
    public decimal GetUploadMinutesForSubscription(SubscriptionType subscriptionType)
    {
        switch (subscriptionType)
        {
            case SubscriptionType.FREE:
                return 30;
            case SubscriptionType.PRO:
                return 60;
            case SubscriptionType.FOUNDERS:
                return 90;
            default:
                return 0;
        }
    }
}