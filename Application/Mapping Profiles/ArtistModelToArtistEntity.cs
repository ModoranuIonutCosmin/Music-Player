using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles
{
    public class ArtistModelToArtistEntity : Profile
    {
        public ArtistModelToArtistEntity()
        {
            CreateMap<ArtistModel, Artist>().ReverseMap();
        }
    }
}
