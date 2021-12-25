using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Song_Access
{
    public class GetMediaFileUrlCommandHandler : IRequestHandler<GetMediaFileUrlCommand, ResourceUrlResponse>
    {
        private readonly IRemoteDiskStorageService remoteDiskStorageService;

        public GetMediaFileUrlCommandHandler(IRemoteDiskStorageService remoteDiskStorageService)
        {
            this.remoteDiskStorageService = remoteDiskStorageService;
        }
        public Task<ResourceUrlResponse> Handle(GetMediaFileUrlCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ResourceUrlResponse()
            {
                Url = remoteDiskStorageService
                .PresignMediaUrl($"song/{request.SongId}", "audio/mpeg", request.Bucket,
                request.AccessKey, request.SecretKey)
            });
        }
    }
}
