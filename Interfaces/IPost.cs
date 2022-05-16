using MovieHolic.Models;

namespace MovieHolic.Interfaces;

public interface IPost
{
    List<Post> GetAll();
    Post GetById(int id);

    Post Details(int id);

    void Insert(Post post);
    void Update(Post post);
    void Delete(Post post);
}