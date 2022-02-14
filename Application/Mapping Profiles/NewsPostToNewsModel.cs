using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping_Profiles;

public class NewsPostToNewsModel: Profile
{
    public NewsPostToNewsModel()
    {
        CreateMap<NewsPost, NewsModel>();
    }
}