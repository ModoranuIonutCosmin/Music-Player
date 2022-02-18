using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Favorites;

public class AddAlbumToFavoritesCommandHandler: IRequestHandler<AddAlbumToFavoritesCommand, UsersFavoriteAlbumsDTO>
{
    private readonly IFavoritesRepository _favoritesRepository;
    private readonly IMapper _mapper;

    public AddAlbumToFavoritesCommandHandler(IFavoritesRepository favoritesRepository,
        IMapper mapper)
    {
        _favoritesRepository = favoritesRepository;
        _mapper = mapper;
    }
    
    public async Task<UsersFavoriteAlbumsDTO> Handle(AddAlbumToFavoritesCommand request, 
        CancellationToken cancellationToken)
    {
        UsersFavoriteAlbums resultingFavoriteEntry
            = await _favoritesRepository.AddFavoriteForAlbum(request.AlbumId, request.RequestingUserId);
        UsersFavoriteAlbumsDTO result = _mapper
            .Map<UsersFavoriteAlbums, UsersFavoriteAlbumsDTO>(resultingFavoriteEntry);

        result.IsFavorite = true;
        
        return result;
    }
}