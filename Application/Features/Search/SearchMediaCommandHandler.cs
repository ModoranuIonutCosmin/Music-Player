using Application.Interfaces;
using AutoMapper;
using Domain.Datamodels;
using Domain.Entities;
using MediatR;

namespace Domain.Models
{
    public class SearchMediaCommandHandler : IRequestHandler<SearchMediaCommand, SearchBarResultsResponse>
    {
        private readonly IAlbumRepository albumRepository;
        private readonly ISongRepository songRepository;
        private readonly IMapper mapper;

        public SearchMediaCommandHandler(IAlbumRepository albumRepository,
            ISongRepository songRepository, IMapper mapper)
        {
            this.albumRepository = albumRepository;
            this.songRepository = songRepository;
            this.mapper = mapper;
        }

        public async Task<SearchBarResultsResponse> Handle(SearchMediaCommand request, CancellationToken cancellationToken)
        {
            var songResults = (await songRepository
                .GetSongByNameSimilarity(request.Query, request.Count, request.Page))
                .Where(s => s.Length > 0)
                .ToList();

            var albumResults = (await albumRepository
                .GetAlbumsByNameSimilarity(request.Query, request.Count, request.Page))
                .Where(a => a.Songs.Any(s => s.Length > 0))
                .ToList();
            
            return new()
            {
                Query = request.Query,
                Results = new SearchBarResult
                {
                    Albums = mapper.Map<List<Album>, List<AlbumResponseDTO>>(albumResults),
                    Songs = mapper.Map <List<Song>, List<SongResponseDTO>>(songResults)
                }
            };
        }
    }
}
