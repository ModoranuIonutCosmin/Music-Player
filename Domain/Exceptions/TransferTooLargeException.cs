namespace Domain.Exceptions
{
    public class TransferTooLargeException : Exception
    {
        public TransferTooLargeException(string message) : base(message)
        {
        }
    }
}
