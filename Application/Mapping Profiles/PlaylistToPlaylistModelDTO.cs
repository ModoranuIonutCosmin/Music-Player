using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles;

public class PlaylistToPlaylistModelDTO : Profile
{
    public PlaylistToPlaylistModelDTO()
    {
        CreateMap<Playlist, PlaylistModel>().ReverseMap();
    }
}