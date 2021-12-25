using Application.Features.Auth.Commands;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping_Profiles
{
    public class RegisterRequestToUserData : Profile
    {

        public RegisterRequestToUserData()
        {
            CreateMap<RegisterUserCommand, Domain.Entities.ApplicationUser>();
            CreateMap<RegisterUserCommand, RegisterResponseDTO>();
        }
    }
}
