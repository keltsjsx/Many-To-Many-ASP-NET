using AutoMapper;
using MovieHolic.Models;
using MovieHolic.ViewModels.PostViewModels;
using MovieHolic.ViewModels.TagViewModels;

namespace MovieHolic.Helpers;

public class Helper : Profile
{
    public Helper()
    {
        CreateMap<Tag, TagViewModel>().ReverseMap();
        CreateMap<CreateTagViewModel, Tag>();
        CreateMap<Post, PostViewModel>().ReverseMap();
    }
}