using LibraryManager.Site.Models;

namespace LibraryManager.Site.Repositories.Interfaces;

public interface IBookRepository
{
    Task <List<BookViewModel>?> GetAllBooks();
    Task<BookViewModel?> GetBookById(Guid id);
}