using Domain.Common;
using Domain.Datamodels;

namespace Domain.Entities;

public class Subscription : BaseEntity
{
    public SubscriptionType Type { get; set; }
    public DateTimeOffset ExpiryDate { get; set; }
    public DateTimeOffset PurchaseDate { get; set; }
    public decimal UploadMinutesUsed { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public Guid ApplicationUserId { get; set; }
}