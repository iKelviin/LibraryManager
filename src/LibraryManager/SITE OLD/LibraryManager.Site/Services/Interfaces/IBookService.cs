using LibraryManager.Site.Models;

namespace LibraryManager.Site.Services.Interfaces;

public interface IBookService
{
    Task<ResultViewModel<List<BookViewModel>>> GetAllBooks();
    Task<ResultViewModel<BookViewModel>> GetBookById(Guid id);
}