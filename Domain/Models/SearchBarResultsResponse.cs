namespace Domain.Models
{
    public class SearchBarResultsResponse
    {
        public string Query { get; set; }
        public List<SearchBarResult> Results { get; set; }
    }
}
