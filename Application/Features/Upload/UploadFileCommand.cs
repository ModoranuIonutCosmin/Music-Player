using System.ComponentModel.DataAnnotations;
using Application.Features.Base;
using Domain.Models;
using MediatR;

namespace Application.Features.Upload;

public class UploadFileCommand: AwsCommand, IRequest<UploadFilesResponseDTO>
{
    public Stream UploadFileStream { get; set; }
    [Required]
    public Guid AlbumId { get; set; }
    [Required]
    public Guid SongId { get; set; }
    public Guid UserRequestingId { get; set; }
}
