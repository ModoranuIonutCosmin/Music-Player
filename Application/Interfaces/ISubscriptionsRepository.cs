using Domain.Entities;

namespace Application.Interfaces;


public interface ISubscriptionsRepository
{
    Task<Subscription> SetUserSubscription(Guid userId, Subscription subscription);
    Task<Subscription> GetUserSubscription(Guid userId);
    Task<Subscription> DeductUserMinutes(Guid userId, decimal amount);
}
