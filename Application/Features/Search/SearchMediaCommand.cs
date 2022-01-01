using MediatR;

namespace Domain.Models
{
    public class SearchMediaCommand : IRequest<SearchBarResultsResponse>
    {
        public string Query { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
    }
}
