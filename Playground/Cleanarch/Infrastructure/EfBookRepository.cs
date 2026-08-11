using Microsoft.EntityFrameworkCore;
using Play.cleanarch.Application;
using Play.cleanarch.Domain;

namespace Play.cleanarch.Infrastructure;

public class EfBookRepository : IBookRepository
{
    private readonly AppDbContext _db;

    // TODO: constructor takes an AppDbContext, assigns it to _db

    // TODO: Add(Book book) -> _db.Books.Add(book); _db.SaveChanges();
    // TODO: GetById(int id) -> Book? -> _db.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
    // TODO: GetAll() -> IEnumerable<Book> -> _db.Books.Include(b => b.Author).ToList();
}
