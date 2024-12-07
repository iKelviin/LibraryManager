using LibraryManager.Site.Models;

namespace LibraryManager.Site.Services.Interfaces;

public interface IBookService
{
    Task<ResultViewModel<List<BookViewModel>>> GetAllBooks(string? searchWord = null);
    Task<ResultViewModel<BookViewModel>> GetBookById(Guid id);
    Task<ResultViewModel<Guid>> Add(BookViewModel book);
}