using Application.Features.Base;
using Domain.Models;
using MediatR;

namespace Application.Features.Upload;

public class UploadFileCommand: AwsCommand, IRequest<UploadFilesResponseDTO>
{
    public Stream FileStream { get; set; }
    public Guid AlbumId { get; set; }
    public Guid SongId { get; set; }
    public Guid UserRequestingId { get; set; }
}
