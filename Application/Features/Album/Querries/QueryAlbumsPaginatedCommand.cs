using System.ComponentModel.DataAnnotations;
using Domain.Models;
using MediatR;

namespace Application.Features.Metadata;

public class QueryAlbumsPaginatedCommand: IRequest<AlbumsListResponseDTO>
{
    [Required]
    public int Page { get; set; }
    [Required]
    public int Count { get; set; }
    public string SortCriteria { get; set; } = "DateAdded";
    public bool Descending { get; set; } = true;
}