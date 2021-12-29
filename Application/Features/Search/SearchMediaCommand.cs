using MediatR;

namespace Domain.Models
{
    public class SearchMediaCommand : IRequest<SearchBarResultsResponse>
    {
        public string Query { get; set; }
    }
}
