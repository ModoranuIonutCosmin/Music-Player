using System.ComponentModel.DataAnnotations;
using Application.Features.Base;
using Domain.Models;
using MediatR;

namespace Application.Features.Song_Access;

public class GetMediaFileUrlCommand : AwsCommand, IRequest<ResourceUrlResponse>
{
    [Required]
    public Guid SongId { get; set; }
}
