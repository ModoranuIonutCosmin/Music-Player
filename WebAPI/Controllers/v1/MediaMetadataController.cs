﻿using Application.Features.Metadata;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers.v1
{
    public class MediaMetadataController : BaseController
    {
        public MediaMetadataController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewAlbumMetadata([FromBody] AlbumModel album)
        {
            var requestingUser = Request.HttpContext.Items["User"] as Domain.Entities.ApplicationUser;

            return Created("album", await mediator.Send<AlbumResponseDTO>(new CreateNewAlbumCommand
            {
                AlbumModel = album,
                Owner = requestingUser,
            }));
        }
    }
}
