using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles;

public class SubscriptionToSubscriptionModel: Profile
{
    public SubscriptionToSubscriptionModel()
    {
        CreateMap<Subscription, SubscriptionModel>();
    }    
}