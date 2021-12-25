namespace Domain.Exceptions
{
    public class InsufficientPermissionException : Exception
    {
        public InsufficientPermissionException(string message) : base(message)
        {
        }
    }
}
