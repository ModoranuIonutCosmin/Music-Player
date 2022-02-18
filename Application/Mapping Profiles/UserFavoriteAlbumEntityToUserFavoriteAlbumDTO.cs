using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles;

public class UserFavoriteAlbumEntityToUserFavoriteAlbumDTO: Profile
{
    public UserFavoriteAlbumEntityToUserFavoriteAlbumDTO()
    {
        CreateMap<UsersFavoriteAlbums, UsersFavoriteAlbumsDTO>();
    }
}