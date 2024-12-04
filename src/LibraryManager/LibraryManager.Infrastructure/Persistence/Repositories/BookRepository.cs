using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryManagerDbContext _context;
    public BookRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Book>> GetAllAsync()
    {
        var books = await _context.Books.Where(x=> !x.IsDeleted).ToListAsync(); 
        
        return books;
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        var book = await _context.Books
            .Where(x=> !x.IsDeleted)
            .SingleOrDefaultAsync(b => b.Id == id);
        
        return book;
    }

    public async Task<Guid> AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book.Id;
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

}