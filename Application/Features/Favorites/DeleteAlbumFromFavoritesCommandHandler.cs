using Application.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Favorites;

public class DeleteAlbumFromFavoritesCommandHandler: IRequestHandler<DeleteAlbumFromFavoritesCommand>
{
    private readonly IFavoritesRepository _favoritesRepository;
    private readonly IMapper _mapper;

    public DeleteAlbumFromFavoritesCommandHandler(IFavoritesRepository favoritesRepository,
        IMapper mapper)
    {
        _favoritesRepository = favoritesRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteAlbumFromFavoritesCommand request,
        CancellationToken cancellationToken)
    {
        if (request.RequestingUserId.Equals(Guid.Empty))
        {
            throw new UnauthorizedAccessException("You have to be logged in to perform this action.");
        }
        
        var succesful = await _favoritesRepository.RemoveFavoriteForAlbum(request.AlbumId,
            request.RequestingUserId);

        if (!succesful)
        {
            throw new AlbumDoesNotExistException("Album does not exist!");
        }
        
        return Unit.Value;
    }
}