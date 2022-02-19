namespace Domain.Exceptions;

public class AlbumDoesNotExistException: Exception
{
    public AlbumDoesNotExistException(string message): base(message)
    {
        
    }
}