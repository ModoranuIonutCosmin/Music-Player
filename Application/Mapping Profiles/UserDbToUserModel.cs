using AutoMapper;

namespace Application.Mapping_Profiles
{
    public class UserDbToUserModel : Profile
    {

        public UserDbToUserModel()
        {
            CreateMap<Domain.Entities.ApplicationUser, Domain.Models.ApplicationUser>().ReverseMap();
        }
    }
}
