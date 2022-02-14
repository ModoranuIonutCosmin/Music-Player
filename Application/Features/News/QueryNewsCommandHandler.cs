
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Features.News;

public class QueryNewsCommandHandler: IRequestHandler<QueryNewsCommand, NewsResponseDTO>
{
    private readonly INewsRepository _newsRepository;
    private readonly IMapper _mapper;

    public QueryNewsCommandHandler(INewsRepository newsRepository,
        IMapper mapper)
    {
        _newsRepository = newsRepository;
        _mapper = mapper;
    }
    
    public async Task<NewsResponseDTO> Handle(QueryNewsCommand request, CancellationToken cancellationToken)
    {
        List<NewsPost> newsPosts = 
            await _newsRepository.LoadNewsPage(request.Page, request.Count);

        return new NewsResponseDTO()
        {
            News = _mapper.Map<List<NewsPost>, List<NewsModel>>(newsPosts),
            Total = await _newsRepository.GetPostsCount()
        };
    }
}