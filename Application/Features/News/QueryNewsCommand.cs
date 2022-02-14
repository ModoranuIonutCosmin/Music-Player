
using Domain.Models;
using MediatR;

namespace Application.Features.News;

public class QueryNewsCommand: IRequest<NewsResponseDTO>
{
    public int Page { get; set; }
    public int Count { get; set; }
}