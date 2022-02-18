using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Application.Interfaces;
using Domain.Models;

namespace Persistence.AWS
{
    public class AwsS3Service : IRemoteDiskStorageService
    {
        private static readonly TimeSpan PRESIGNED_MEDIA_URL_EXPIRY_TIME = TimeSpan.FromDays(2);
        private static AmazonS3Client SetupClient(string awsAccessKey, string awsSecretKey)
        {
            var credentials = new BasicAWSCredentials(awsAccessKey, awsSecretKey);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUCentral1
            };

            return new AmazonS3Client(credentials, config);
        }

        public ResourceUrlResponse PresignMediaUrl(string resourceKey, string format, string bucket, string awsAccessKey, string awsSecretKey)
        {
            using var client = SetupClient(awsAccessKey, awsSecretKey);

            DateTime expirationDate = DateTime.UtcNow.Add(PRESIGNED_MEDIA_URL_EXPIRY_TIME);

            var url = client.GetPreSignedURL(new GetPreSignedUrlRequest()
            {
                BucketName = bucket,
                Key = resourceKey,
                Expires = expirationDate,
            });

            return new()
            {
                Expires = expirationDate,
                Url = url
            };
        }
        
        /// <summary>
        /// Upload a file with maximum size 2GB.
        /// </summary>
        public async Task UploadSmallFile(MemoryStream fileStream, string fileName, string bucket, string awsAccessKey,
            string awsSecretKey)
        {
            using var client = SetupClient(awsAccessKey, awsSecretKey);
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = fileStream,
                Key = fileName,
                BucketName = bucket,
            };
            var fileTransferUtility = new TransferUtility(client);

            await fileTransferUtility.UploadAsync(uploadRequest);
        }
    }
}
