using Application.Features.Upload;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers.v1
{
    public class MediaUploadController : BaseController
    {
        private readonly IConfiguration configuration;

        public MediaUploadController(IMediator mediator, IConfiguration configuration) : base(mediator)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UploadFiles(Guid albumId, Guid songId, IFormFile formFile)
        {
            var uploadRequest = new UploadFileCommand
            {
                FileStream = formFile.OpenReadStream(),
                SongId = songId,
                AlbumId = albumId,
                AccessKey = configuration["AWSAccessKey"],
                Bucket = configuration["DefaultBucket"],
                SecretKey = configuration["AWSSecretKey"],
                UserRequestingId = (Request.HttpContext.Items["User"] as ApplicationUser).Id
            };

            return Ok(await mediator.Send(uploadRequest));
        }

        
    }
}
