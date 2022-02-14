using Domain.Entities;

namespace Application.Interfaces;

public interface INewsRepository : IRepository<NewsPost>
{
    Task<List<NewsPost>> LoadNewsPage(int page, int count);
}