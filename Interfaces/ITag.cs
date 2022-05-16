using MovieHolic.Models;

namespace MovieHolic.Interfaces;

public interface ITag
{
    List<Tag> GetAll();
    Tag GetById(int id);
    void Insert(Tag tag);
    void Update(Tag tag);
    void Delete(Tag tag);
}