using Domain.Datamodels;

namespace Application.Services;

public interface ISubscriptionsService
{
    void GrantSubscriptionPlan(Guid userId, SubscriptionType subscriptionType,
        int dayCount = 36500);
    bool UserHasEnoughMinutesForUpload(Guid userId, decimal uploadMinutesCount);
    Task DeductUserMinutes(Guid userId, decimal uploadMinutesCount);
    decimal GetUploadMinutesForSubscription(SubscriptionType subscriptionType);
}