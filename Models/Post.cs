using System.ComponentModel.DataAnnotations;

namespace MovieHolic.Models;

public class Post
{
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<PostTag> PostTags { get; set; } = new List<PostTag>();
}