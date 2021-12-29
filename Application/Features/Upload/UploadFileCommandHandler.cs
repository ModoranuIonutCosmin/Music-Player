using Application.Audio_File_Tagging;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Models;
using MediatR;
using static TagLib.File;

namespace Application.Features.Upload
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadFilesResponseDTO>
    {
        public const int TRANSFER_LIMIT = 16_000_000;
        private readonly IRemoteDiskStorageService diskStorageService;
        private readonly IAlbumRepository albumRepository;
        private readonly IStorageInfoRepository storageInfoRepository;
        private readonly ISongRepository songRepository;

        public UploadFileCommandHandler(IRemoteDiskStorageService diskStorageService,
            IAlbumRepository albumRepository,
            IStorageInfoRepository storageInfoRepository,
            ISongRepository songRepository)
        {
            this.diskStorageService = diskStorageService;
            this.albumRepository = albumRepository;
            this.storageInfoRepository = storageInfoRepository;
            this.songRepository = songRepository;
        }

        public async Task<UploadFilesResponseDTO> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            long requestSize = request.FileStream.Length;

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

            if (newSongId == Guid.Empty || await songRepository.GetByIdAsync(newSongId) == null)
            {
                throw new ArgumentException($"{nameof(request.SongId)} invalid!");
            }

            var storageInfo = await storageInfoRepository.FindBySongId(newSongId);

            if (storageInfo != null)
            {
                throw new FileAlreadyUploadedException("Can't link one more media file with this song.");
            }

            var memoryStream = new MemoryStream();
           
            try
            {
                await request.FileStream.CopyToAsync(memoryStream, cancellationToken);

                await diskStorageService.UploadSmallFile(memoryStream, "songs/" + newSongId, request.Bucket,
                    request.AccessKey, request.SecretKey);

                //TODO: -Facut servicii pentru fiecare lucru diferit
                // -identificare tip fisier dupa header-ul din binary.

                //Tagging
                memoryStream = new MemoryStream(memoryStream.ToArray());

                IFileAbstraction file = new SimpleAudioFileAbstraction(new SimpleAudioFile("file", memoryStream));

                var audioFileProperties = Create(file, "audio/mp3", TagLib.ReadStyle.Average);
                var extension = "mp3";

                await storageInfoRepository.AddAsync(new Storage()
                {
                    SongId = newSongId,
                    Path = $"songs/{newSongId}",
                    Size = requestSize,
                    Extension = extension
                });

                await songRepository.SetSongDuration(newSongId, audioFileProperties?.Properties?.Duration.Ticks ?? 0);
            }

            finally
            {
                await memoryStream.DisposeAsync();
            }
             
            return new UploadFilesResponseDTO
            {
                TotalBytesSize = requestSize
            };
        }
    }
}
