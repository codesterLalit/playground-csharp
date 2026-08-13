using Microsoft.EntityFrameworkCore;
using Play.cleanarch.Application;
using Play.cleanarch.Domain;

namespace Play.cleanarch.Infrastructure;

public class EfBookRepository : IBookRepository
{
    private readonly AppDbContext _db;

    public EfBookRepository(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    public void Add(Book book)
    {
        var existingBook = _db.Books.FirstOrDefault(b => b.Id == book.Id);

        if (existingBook is null)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }
    }

    public Book? GetById(int id)
    {
        Book? book = _db.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        return book;
    }

    public IEnumerable<Book> GetAll()
    {
        var bookList = _db.Books.Include(b => b.Author).ToList();
        return bookList;
    }
}