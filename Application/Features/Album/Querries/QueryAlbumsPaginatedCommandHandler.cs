using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Features.Metadata;

public class QueryAlbumsPaginatedCommandHandler : IRequestHandler<QueryAlbumsPaginatedCommand, AlbumsListResponseDTO>
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;

    public QueryAlbumsPaginatedCommandHandler(IAlbumRepository albumRepository,
        IMapper mapper)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
    }

    public async Task<AlbumsListResponseDTO> Handle(QueryAlbumsPaginatedCommand request,
        CancellationToken cancellationToken)
    {
        List<Album> albumOnThisPage;
        
        switch (request.SortCriteria)
        {
            case "popularity":
                albumOnThisPage = await _albumRepository
                    .GetAllAlbumsPaginatedOrderedByAddedDate(request.Page, request.Count, request.Descending);
                break;
            default:
                albumOnThisPage = await _albumRepository
                    .GetAllAlbumsPaginatedOrderedByFavoritesVotes(request.Page, request.Count, request.Descending);
                break;
        }

        albumOnThisPage = albumOnThisPage
            .Where(a => a.Songs.Any(s => s.Length > 0))
            .ToList();

        return new AlbumsListResponseDTO()
        {
            Albums = _mapper.Map<List<Album>, List<AlbumResponseDTO>>(albumOnThisPage),
            Count = request.Count,
            Page = request.Page,
            ReturnedAlbumsCount = albumOnThisPage.Count,
            TotalAlbumsCount = await _albumRepository.GetAlbumsTotalCount()
        };
    }
}