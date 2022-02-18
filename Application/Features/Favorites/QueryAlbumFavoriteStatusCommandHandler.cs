using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Features.Favorites;

public class QueryAlbumFavoriteStatusCommandHandler
    : IRequestHandler<QueryAlbumFavoriteStatusCommand, UsersFavoriteAlbumsDTO>
{
    private readonly IFavoritesRepository _favoritesRepository;
    private readonly IMapper _mapper;

    public QueryAlbumFavoriteStatusCommandHandler(IFavoritesRepository favoritesRepository,
        IMapper mapper)
    {
        _favoritesRepository = favoritesRepository;
        _mapper = mapper;
    }
    
    public async Task<UsersFavoriteAlbumsDTO> Handle(QueryAlbumFavoriteStatusCommand request,
        CancellationToken cancellationToken)
    {
        UsersFavoriteAlbums favoriteEntry = await _favoritesRepository.GetFavoriteEntryForUser
                                    (request.RequestingUserId, request.AlbumId);

        if (favoriteEntry == null)
        {
            return new UsersFavoriteAlbumsDTO
            {
                IsFavorite = false
            };
        }

        return _mapper.Map<UsersFavoriteAlbums, UsersFavoriteAlbumsDTO>(favoriteEntry);
    }
}