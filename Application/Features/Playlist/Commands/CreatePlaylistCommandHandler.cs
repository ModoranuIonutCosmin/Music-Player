using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using MediatR;

namespace Application.Features.Playlist.Commands;

public class CreatePlaylistCommandHandler: IRequestHandler<CreatePlaylistCommand, PlaylistCreationResponseDTO>
{
    private readonly IPlaylistRepository _playlistRepository;
    private readonly IUserRepository _userRepository;

    public CreatePlaylistCommandHandler(IPlaylistRepository playlistRepository,
        IUserRepository userRepository)
    {
        _playlistRepository = playlistRepository;
        _userRepository = userRepository;
    }
    public async Task<PlaylistCreationResponseDTO> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
    {
        var requestingUser = await _userRepository.GetByIdAsync(request.RequestingUserId);
        if (requestingUser == null)
        {
            throw new UserNotFoundException("Invalid user supplied");
        }

        Domain.Entities.Playlist playlist = new Domain.Entities.Playlist()
        {
            Songs = new(),
            User = requestingUser,
            Name = request.Name,
            Visibility = request.Visibility
        };

        await _playlistRepository.AddAsync(playlist);

        return new()
        {
            PlaylistId = playlist.Id
        };
    }
}