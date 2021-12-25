using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles
{
    public class AlbumEntityToAlbumResponseDTO : Profile
    {
        public AlbumEntityToAlbumResponseDTO()
        {
            CreateMap<Album, AlbumResponseDTO>();
        }
    }
}
