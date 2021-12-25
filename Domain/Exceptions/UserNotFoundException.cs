namespace Domain.Exceptions;
public class UserNotFoundException : Exception
{
    public UserNotFoundException(string input) : base(input)
    {

    }
}
