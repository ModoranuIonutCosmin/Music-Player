using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Features.Metadata;

public class GetAlbumDetailedInfoCommandHandler : IRequestHandler<GetAlbumDetailedInfoCommand, AlbumResponseDTO>
{
    private readonly IAlbumRepository albumRepository;
    private readonly IMapper mapper;

    public GetAlbumDetailedInfoCommandHandler(IAlbumRepository albumRepository, IMapper mapper)
    {
        this.albumRepository = albumRepository;
        this.mapper = mapper;
    }
    public async Task<AlbumResponseDTO> Handle(GetAlbumDetailedInfoCommand request, CancellationToken cancellationToken)
    {
        Album albumFullInfo = await albumRepository.GetAllAlbumInformationByAlbumId(request.AlbumId);

        return mapper.Map<Album, AlbumResponseDTO>(albumFullInfo);
    }
}
