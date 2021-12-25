using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Models;
using MediatR;

namespace Application.Features.Upload
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadFilesResponseDTO>
    {
        public const int TRANSFER_LIMIT = 6_000_000;
        private readonly IRemoteDiskStorageService diskStorageService;
        private readonly IAlbumRepository albumRepository;
        private readonly IStorageInfoRepository storageInfoRepository;

        public UploadFileCommandHandler(IRemoteDiskStorageService diskStorageService,
            IAlbumRepository albumRepository,
            IStorageInfoRepository storageInfoRepository)
        {
            this.diskStorageService = diskStorageService;
            this.albumRepository = albumRepository;
            this.storageInfoRepository = storageInfoRepository;
        }

        public async Task<UploadFilesResponseDTO> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            long requestSize = request.FileStream.Length;
            long uploadedSize = 0;

            if(requestSize >= TRANSFER_LIMIT)
            {
                throw new TransferTooLargeException($"{requestSize} bytes is too large for a total files size");
            }

            var album = await albumRepository.GetByIdAsync(request.AlbumId);

            if (album  == null || album.Owner.Id != request.UserRequestingId)
            {
                throw new InsufficientPermissionException($"You're not the owner of this album!");
            }

            Guid newSongId = request.SongId;

            var storageInfo = await storageInfoRepository.GetByIdAsync(newSongId);

            if (storageInfo != null)
            {
                throw new FileAlreadyUploadedException("Can't link one more media file with this song.");
            }

            var memoryStream = new MemoryStream();

            try
            {
                uploadedSize += memoryStream.Length;

                await request.FileStream.CopyToAsync(memoryStream, cancellationToken);

                await diskStorageService.UploadSmallFile(memoryStream, "songs/" + newSongId, request.Bucket,
                    request.AccessKey, request.SecretKey);

                await storageInfoRepository.AddAsync(new Storage()
                {
                    SongId = newSongId.ToString(),
                    Path = $"songs/{newSongId}",
                    Size = uploadedSize
                });
            }

            finally
            {
                await memoryStream.DisposeAsync();
            }
             
            return new UploadFilesResponseDTO
            {
                TotalBytesSize = uploadedSize
            };
        }
    }
}
