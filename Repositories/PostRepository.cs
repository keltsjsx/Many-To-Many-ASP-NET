using Microsoft.EntityFrameworkCore;
using MovieHolic.Interfaces;
using MovieHolic.Models;

namespace MovieHolic.Repositories;

public class PostRepository : IPost
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Delete(Post post)
    {
        _context.Post.Remove(post);
    }

    public Post Details(int id)
    {
        return _context.Post.Include(x => x.PostTags).ThenInclude(y => y.Tag).SingleOrDefault(m => m.Id == id);
    }

    public List<Post> GetAll()
    {
        return _context.Post.ToList();
    }

    public Post GetById(int id)
    {
        return _context.Post.Include("PostTags.Tag").FirstOrDefault(x => x.Id == id);
    }

    public void Insert(Post post)
    {
        _context.Post.Add(post);
    }

    public void Update(Post post)
    {
        _context.Post.Update(post);
    }
}