using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Song_Access;

public class GetSongDetailedInfCommandHandler : IRequestHandler<GetSongDetailedInfoCommand, SongResponseDTO>
{
    private readonly ISongRepository songRepository;
    private readonly IMapper mapper;

    public GetSongDetailedInfCommandHandler(ISongRepository songRepository, IMapper mapper)
    {
        this.songRepository = songRepository;
        this.mapper = mapper;
    }

    public async Task<SongResponseDTO> Handle(GetSongDetailedInfoCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Song songData = await songRepository.LoadSongRelatedData(request.SongId);

        return mapper.Map<Domain.Entities.Song, SongResponseDTO>(songData);
    }
}
