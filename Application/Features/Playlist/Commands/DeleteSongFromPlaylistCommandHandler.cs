using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Playlist.Commands;

public class DeleteSongFromPlaylistCommandHandler: IRequestHandler<DeleteSongFromPlaylistCommand, PlaylistModel>
{
    private readonly IPlaylistRepository _playlistRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public DeleteSongFromPlaylistCommandHandler(IPlaylistRepository playlistRepository,
        IUserRepository userRepository,
        ISongRepository songRepository,
        IMapper mapper)
    {
        _playlistRepository = playlistRepository;
        _userRepository = userRepository;
        _songRepository = songRepository;
        _mapper = mapper;
    }
    public async Task<PlaylistModel> Handle(DeleteSongFromPlaylistCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Playlist playlist = await _playlistRepository.GetByIdAsync(request.PlaylistId);
        ApplicationUser requestingUser = await _userRepository.GetByIdAsync(request.RequestingUserId);
        Song song = await _songRepository.GetByIdAsync(request.SongId);
        
        if (playlist == null)
        {
            throw new PlaylistDoesNotExist("Playlist id is invalid!");
        }

        if (song == null)
        {
            throw new InexistentMediaFileException("Song doesn't exist!");
        }

        if (requestingUser == null || playlist.User.Id != requestingUser.Id)
        {
            throw new UnauthorizedAccessException("User can't modify this playlist!");
        }

        await _playlistRepository.DeleteSongFromPlaylistAsync(song, playlist);

        return _mapper.Map<Domain.Entities.Playlist, PlaylistModel>(playlist);
    }
}