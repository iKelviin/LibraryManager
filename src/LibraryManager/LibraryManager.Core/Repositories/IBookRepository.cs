using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(Book book);
    Task UpdateAsync(Book book);
}