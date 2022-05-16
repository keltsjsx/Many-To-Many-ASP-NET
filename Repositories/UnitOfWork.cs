using MovieHolic.Interfaces;

namespace MovieHolic.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context  = context;
        Post = new PostRepository(_context);
        Tag = new TagRepository(_context);
    }

    public IPost Post{ get; private set; }

    public ITag Tag { get; private set; }

    public void Save()
    {
        _context.SaveChanges();
    }
}