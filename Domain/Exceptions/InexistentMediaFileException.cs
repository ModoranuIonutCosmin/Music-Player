namespace Domain.Exceptions
{
    public class InexistentMediaFileException : Exception
    {
        public InexistentMediaFileException(string message) : base(message)
        {
        }
    }
}
