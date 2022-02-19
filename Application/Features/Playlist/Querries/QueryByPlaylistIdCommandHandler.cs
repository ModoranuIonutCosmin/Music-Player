using Application.Interfaces;
using AutoMapper;
using Domain.Datamodels;
using Domain.Exceptions;
using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Querries;

public class QueryByPlaylistIdCommandHandler : IRequestHandler<QueryByPlaylistIdCommand, PlaylistModel>
{
    private readonly IPlaylistRepository _playlistRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public QueryByPlaylistIdCommandHandler(IPlaylistRepository playlistRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _playlistRepository = playlistRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<PlaylistModel> Handle(QueryByPlaylistIdCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Playlist playlist = await _playlistRepository.LoadPlaylistsSongs(request.PlaylistId);

        if (playlist == null)
        {
            throw new PlaylistDoesNotExist("Invalid playlist!");
        }

        if (!playlist.User.Id.Equals(request.RequestingUserId) && playlist.Visibility == Visibility.Private)
        {
            throw new UnauthorizedAccessException("This playlist is private!");
        }
        
        PlaylistModel result = _mapper.Map<Domain.Entities.Playlist, PlaylistModel>(playlist);
        
        int songPosition = 0;
        result.Songs.ForEach((song) =>
        {
            songPosition++;
            song.Position = songPosition;
        });

        return result;
    }
}