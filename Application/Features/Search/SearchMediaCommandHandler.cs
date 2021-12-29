using Application.Interfaces;
using Domain.Datamodels;
using MediatR;

namespace Domain.Models
{
    public class SearchMediaCommandHandler : IRequestHandler<SearchMediaCommand, SearchBarResultsResponse>
    {
        private readonly IAlbumRepository albumRepository;
        private readonly ISongRepository songRepository;

        public SearchMediaCommandHandler(IAlbumRepository albumRepository,
            ISongRepository songRepository)
        {
            this.albumRepository = albumRepository;
            this.songRepository = songRepository;
        }

        public async Task<SearchBarResultsResponse> Handle(SearchMediaCommand request, CancellationToken cancellationToken)
        {
            var searchResults = (await songRepository
                .GetSongByNameSimilarity(request.Query))
                .Select(e => new SearchBarResult
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = MediaFileType.Song
                }).ToList();

            searchResults.AddRange((await albumRepository
                .GetAlbumsByNameSimilarity(request.Query))
                .Select(e => new SearchBarResult
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = MediaFileType.Album
                }));

            return new()
            {
                Query = request.Query,
                Results = searchResults
            };
        }
    }
}
