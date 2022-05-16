using MovieHolic.Interfaces;
using MovieHolic.Models;

namespace MovieHolic.Repositories;

public class TagRepository : ITag
{
    private readonly ApplicationDbContext _context;

    public TagRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Delete(Tag tag)
    {
       _context.Tag.Remove(tag);
    }

    public List<Tag> GetAll()
    {
        return _context.Tag.ToList();
    }

    public Tag GetById(int id)
    {
       return _context.Tag.FirstOrDefault(t => t.Id == id);
    }

    public void Insert(Tag tag)
    {
        _context.Tag.Add(tag);
    }

    public void Update(Tag tag)
    {
        _context.Tag.Update(tag);
    }
}