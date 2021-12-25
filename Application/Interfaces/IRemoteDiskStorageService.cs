namespace Application.Interfaces
{
    public interface IRemoteDiskStorageService
    {
        string PresignMediaUrl(string resourceKey, string format, string bucket, string awsAccessKey, string awsSecretKey);
        Task UploadSmallFile(MemoryStream fileStream, string fileName, string bucket, string awsAccessKey, string awsSecretKey);
    }
}