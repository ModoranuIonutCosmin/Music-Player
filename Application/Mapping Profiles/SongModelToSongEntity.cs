using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles
{
    public class SongModelToSongEntity : Profile
    {
        public SongModelToSongEntity()
        {
            CreateMap<SongModel, Song>();
        }
    }
}
