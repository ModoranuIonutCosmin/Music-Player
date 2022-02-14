using AutoMapper;
using Domain.Models;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Mapping_Profiles;

public class ApplicationUserToUserProfileDTO: Profile
{
    public ApplicationUserToUserProfileDTO()
    {
        CreateMap<ApplicationUser, UserProfileModel>();
    }
}