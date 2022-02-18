using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Features.Metadata;

public class CreateNewAlbumCommandHandler : IRequestHandler<CreateNewAlbumCommand, AlbumResponseDTO>
{
    private readonly IMapper _mapper;
    private readonly IAlbumRepository _albumRepository;

    public CreateNewAlbumCommandHandler(IMapper mapper, IAlbumRepository albumRepository)
    {
        this._mapper = mapper;
        this._albumRepository = albumRepository;
    }
    public async Task<AlbumResponseDTO> Handle(CreateNewAlbumCommand request, CancellationToken cancellationToken)
    {
        var albumModel = request.AlbumModel;

        Album newAlbum = _mapper.Map<AlbumModel, Album>(albumModel);

        newAlbum.DateAdded = DateTimeOffset.UtcNow;

        newAlbum.Songs.ForEach(song => song.CoverImageUrl = newAlbum.CoverImageUrl);

        HashSet<Artist> allAlbumArtists = new();

        foreach (SongModel songModel in albumModel.Songs)
        {
            List<Artist> songArtists = _mapper.Map<List<ArtistModel>, List<Artist>>(songModel.Artists);

            allAlbumArtists.UnionWith(songArtists);
        }
        
        newAlbum.Owner = request.Owner;
        newAlbum.Artists = new List<Artist>(allAlbumArtists);

        Album resultingAlbum = await _albumRepository.AddAsync(newAlbum);

        var result = _mapper.Map<Album, AlbumResponseDTO>(resultingAlbum);

        return result;
    }
}
