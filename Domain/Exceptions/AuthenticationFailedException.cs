namespace Domain.Exceptions;

public class AuthenticationFailedException : Exception
{
    public AuthenticationFailedException(string input) : base(input)
    {

    }
}

