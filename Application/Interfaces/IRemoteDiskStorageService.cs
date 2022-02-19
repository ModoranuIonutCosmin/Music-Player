using Domain.Models;

namespace Application.Interfaces
{
    public interface IRemoteDiskStorageService
    {
        ResourceUrlResponse PresignMediaUrl(string resourceKey, string format, string bucket, string awsAccessKey, string awsSecretKey);
        Task UploadSmallFile(MemoryStream fileStream, string fileName, string bucket, string awsAccessKey, string awsSecretKey);
    }
}