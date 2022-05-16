namespace MovieHolic.Models;

public class Tag
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public List<PostTag> PostTags { get; set; }
}