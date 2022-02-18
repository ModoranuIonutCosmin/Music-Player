using Domain.Models;
using MediatR;

namespace Application.Features.Metadata
{
    public class CreateNewAlbumCommand : IRequest<AlbumResponseDTO>
    {
        public Domain.Entities.ApplicationUser Owner { get; set; }
        public AlbumModel AlbumModel { get; set; }
    }
}
