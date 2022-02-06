namespace Domain.Exceptions;

public class PlaylistDoesNotExist: Exception
{
    public PlaylistDoesNotExist(string? message) : base(message)
    {
        
    }
}