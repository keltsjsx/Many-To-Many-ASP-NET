namespace MovieHolic.Interfaces;

public interface IUnitOfWork
{
    IPost Post { get; }
    ITag Tag { get; }
    void Save();
}