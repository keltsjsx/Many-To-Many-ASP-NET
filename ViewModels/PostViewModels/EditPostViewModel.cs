using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieHolic.ViewModels.PostViewModels;

public class EditPostViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<SelectListItem> Tags { get; set; }
    public string[] SelectedTags { get; set; }
}