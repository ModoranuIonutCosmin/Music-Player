using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Domain.Models
{
    public class SearchMediaCommand : IRequest<SearchBarResultsResponse>
    {
        [Required]
        [MaxLength(4000)]
        public string Query { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Page { get; set; }
    }
}
