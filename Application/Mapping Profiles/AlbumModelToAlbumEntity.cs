using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles
{
    public class AlbumModelToAlbumEntity : Profile
    {

        public AlbumModelToAlbumEntity()
        {
            CreateMap<AlbumModel, Album>()
                .ForSourceMember(source => source.Songs, opt => opt.DoNotValidate());
        }
    }
}
