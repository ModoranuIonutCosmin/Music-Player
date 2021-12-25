using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Application.Interfaces;

namespace Persistence.AWS
{
    public class AwsS3Service : IRemoteDiskStorageService
    {
        private AmazonS3Client SetupClient(string awsAccessKey, string awsSecretKey)
        {
            var credentials = new BasicAWSCredentials(awsAccessKey, awsSecretKey);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUCentral1
            };

            return new AmazonS3Client(credentials, config);
        }

        public string PresignMediaUrl(string resourceKey, string format, string bucket, string awsAccessKey, string awsSecretKey)
        {
            using var client = SetupClient(awsAccessKey, awsSecretKey);

            var url = client.GetPreSignedURL(new GetPreSignedUrlRequest()
            {
                BucketName = bucket,
                Key = resourceKey,
                Expires = DateTime.UtcNow.AddDays(2),
            });

            return url;
        }

        public async Task UploadSmallFile(MemoryStream fileStream, string fileName, string bucket, string awsAccessKey, string awsSecretKey)
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
