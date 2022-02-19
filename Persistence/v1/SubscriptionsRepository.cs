using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1;

public class SubscriptionsRepository : Repository<Subscription>, ISubscriptionsRepository  
{
    
    public SubscriptionsRepository(MediaPlayerContext context) : base(context)
    {
    }
    
    public async Task<Subscription> SetUserSubscription(Guid userId, Subscription subscription)
    {
        ApplicationUser user = await Context.Users
            .Where(u => u.Id.Equals(userId))
            .SingleOrDefaultAsync();
        
        if (user == null)
        {
            return default;
        }

        user.Subscription.Type = subscription.Type;
        user.Subscription.ExpiryDate = subscription.ExpiryDate;
        user.Subscription.PurchaseDate = subscription.PurchaseDate;

        await Context.SaveChangesAsync();

        return user.Subscription;
    }

    public async Task<Subscription> GetUserSubscription(Guid userId)
    {
        ApplicationUser user = await Context.Users
            .Where(u => u.Id.Equals(userId))
            .Include(u => u.Subscription)
            .SingleOrDefaultAsync();

        return user?.Subscription;
    }

    public async Task<Subscription> DeductUserMinutes(Guid userId, decimal amount)
    {
        ApplicationUser user = await Context.Users
            .Where(u => u.Id.Equals(userId))
            .SingleOrDefaultAsync();

        user.Subscription.UploadMinutesUsed += amount;

        await Context.SaveChangesAsync();

        return user.Subscription;
    }
}