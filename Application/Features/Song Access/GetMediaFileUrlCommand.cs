using Application.Features.Base;
using Domain.Models;
using MediatR;

namespace Application.Features.Song_Access;

public class GetMediaFileUrlCommand : AwsCommand, IRequest<ResourceUrlResponse>
{
    public Guid SongId { get; set; }
}
