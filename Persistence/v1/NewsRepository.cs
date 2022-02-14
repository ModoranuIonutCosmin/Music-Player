using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1;

public class NewsRepository : Repository<NewsPost>, INewsRepository
{
    public NewsRepository(MediaPlayerContext context) : base(context)
    {
    }
    
    public async Task<List<NewsPost>> LoadNewsPage(int page, int count)
    {
        return await Context.News
            .OrderByDescending(e => e.DateCreated)
            .Skip(page * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task<long> GetPostsCount()
    {
        return await this.Context.News.CountAsync();
    }
}