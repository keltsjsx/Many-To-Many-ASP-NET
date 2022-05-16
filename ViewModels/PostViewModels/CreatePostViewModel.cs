using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHolic.ViewModels.TagViewModels;

namespace MovieHolic.ViewModels.PostViewModels;

public class CreatePostViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<SelectListItem> Tags { get; set; }
    public string[] SelectedTags { get; set; }
}