using System.ComponentModel.DataAnnotations;

namespace MovieHolic.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public string? Genre { get; set; }
}