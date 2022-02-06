namespace Domain.Exceptions;

public class UserDoesNotOwnPlaylist: Exception
{
    public UserDoesNotOwnPlaylist(string? message) : base(message)
    {
    }
}