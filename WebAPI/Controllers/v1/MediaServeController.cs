using Application.Features.Song_Access;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1;

public class MediaServeController : BaseController
{
    private readonly IConfiguration configuration;

    public MediaServeController(IMediator mediator, IConfiguration configuration) : base(mediator)
    {
        this.configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetMediaUrl(Guid songId)
    {
        return Ok(mediator.Send(new GetMediaFileUrlCommand()
        {
            SongId = songId,
            Bucket = configuration["DefaultBucket"],
            AccessKey = configuration["AWSAccessKey"],
            SecretKey = configuration["AWSSecretKey"]
        }));
    }
}
