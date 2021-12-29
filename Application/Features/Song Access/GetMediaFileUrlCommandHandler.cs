using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using MediatR;

namespace Application.Features.Song_Access
{
    public class GetMediaFileUrlCommandHandler : IRequestHandler<GetMediaFileUrlCommand, ResourceUrlResponse>
    {
        private readonly IRemoteDiskStorageService remoteDiskStorageService;
        private readonly IStorageInfoRepository storageInfoRepository;

        public GetMediaFileUrlCommandHandler(IRemoteDiskStorageService remoteDiskStorageService,
            IStorageInfoRepository storageInfoRepository)
        {
            this.remoteDiskStorageService = remoteDiskStorageService;
            this.storageInfoRepository = storageInfoRepository;
        }
        public async Task<ResourceUrlResponse> Handle(GetMediaFileUrlCommand request, CancellationToken cancellationToken)
        {
            var storageInfo = await storageInfoRepository.FindBySongId(request.SongId);

            if (storageInfo == null)
            {
                throw new InexistentMediaFileException($"Can't find a file with such songId ({request.SongId}) !");
            }

            if (storageInfo.Url != null && storageInfo?.UrlExpiration > DateTimeOffset.UtcNow)
            {
                return new ResourceUrlResponse()
                {
                    Url = storageInfo.Url,
                    Expires = storageInfo.UrlExpiration
                };
            }

            var presignedUrlData = remoteDiskStorageService
                .PresignMediaUrl(storageInfo.Path, "audio/mpeg", request.Bucket, request.AccessKey, request.SecretKey);

            await storageInfoRepository.UpdateFileUrl(storageInfo.Id, presignedUrlData.Url, presignedUrlData.Expires);

            return presignedUrlData;
        }
    }
}
