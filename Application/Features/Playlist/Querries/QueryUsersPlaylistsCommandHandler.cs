using Application.Interfaces;
using AutoMapper;
using Domain.Datamodels;
using Domain.Exceptions;
using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Querries;

public class QueryUsersPlaylistsCommandHandler : IRequestHandler<QueryUsersPlaylistsCommand, PlaylistsResponseDTO>
{
    private readonly IPlaylistRepository _playlistRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public QueryUsersPlaylistsCommandHandler(IPlaylistRepository playlistRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _playlistRepository = playlistRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PlaylistsResponseDTO> Handle(QueryUsersPlaylistsCommand request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Playlist> playlists = await _playlistRepository
            .GetUsersPlaylistsAsync(request.RequestingUserId);

        return new PlaylistsResponseDTO()
        {
            Playlists = _mapper.Map<List<Domain.Entities.Playlist>, List<PlaylistModel>>(playlists)
        };
    }
}