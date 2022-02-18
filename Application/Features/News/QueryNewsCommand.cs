
using System.ComponentModel.DataAnnotations;
using Domain.Models;
using MediatR;

namespace Application.Features.News;

public class QueryNewsCommand: IRequest<NewsResponseDTO>
{
    [Required]
    public int Page { get; set; }
    [Required]
    public int Count { get; set; }
}