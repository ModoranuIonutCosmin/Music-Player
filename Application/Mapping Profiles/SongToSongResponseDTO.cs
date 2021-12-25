using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles
{
    public class SongToSongResponseDTO : Profile
    {
        public SongToSongResponseDTO()
        {
            CreateMap<Song, SongResponseDTO>();
        }
    }
}
