using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Features.Metadata;

public class CreateNewAlbumCommandHandler : IRequestHandler<CreateNewAlbumCommand, AlbumResponseDTO>
{
    private readonly IMapper mapper;
    private readonly IAlbumRepository albumRepository;

    public CreateNewAlbumCommandHandler(IMapper mapper, IAlbumRepository albumRepository)
    {
        this.mapper = mapper;
        this.albumRepository = albumRepository;
    }
    public async Task<AlbumResponseDTO> Handle(CreateNewAlbumCommand request, CancellationToken cancellationToken)
    {
        var albumModel = request.AlbumModel;

        Album newAlbum = mapper.Map<AlbumModel, Album>(albumModel);

        HashSet<Artist> allAlbumArtists = new();

        foreach (SongModel songModel in albumModel.Songs)
        {
            List<Artist> songArtists = mapper.Map<List<ArtistModel>, List<Artist>>(songModel.Artists);

            allAlbumArtists.UnionWith(songArtists);
        }
        newAlbum.Owner = request.Owner;
        newAlbum.Artists = new List<Artist>(allAlbumArtists);

        Album resultingAlbum = await albumRepository.AddAsync(newAlbum);

        var result = mapper.Map<Album, AlbumResponseDTO>(resultingAlbum);

        return result;
    }
}
