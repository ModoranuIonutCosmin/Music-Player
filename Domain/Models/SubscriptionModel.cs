using Domain.Datamodels;

namespace Domain.Models;

public class SubscriptionModel
{
    public SubscriptionType Type { get; set; }
    public DateTimeOffset ExpiryDate { get; set; }
    public DateTimeOffset PurchaseDate { get; set; }
    public decimal UploadMinutesUsed { get; set; }
}