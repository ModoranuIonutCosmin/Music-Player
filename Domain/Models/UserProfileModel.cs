namespace Domain.Models;

public class UserProfileModel
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public SubscriptionModel Subscription { get; set; }
}