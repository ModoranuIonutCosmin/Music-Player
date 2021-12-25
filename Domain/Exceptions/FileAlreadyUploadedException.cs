namespace Domain.Exceptions
{
    public class FileAlreadyUploadedException : Exception
    {
        public FileAlreadyUploadedException(string message) : base(message)
        {
        }
    }
}
