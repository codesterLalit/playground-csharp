using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public interface IBookRepository
{
    public void Add(Book book);
    public Book? GetById(int id);
    public IEnumerable<Book> GetAll();
}