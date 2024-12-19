using LibraryManager.Site.Models;

namespace LibraryManager.Site.Services.Interfaces;

public interface IBookService
{
    Task<ResultViewModel<List<BookViewModel>>> GetAllBooks(string? searchWord = null);
    Task<ResultViewModel<BookViewModel>> GetBookById(Guid id);
    Task<ResultViewModel<Guid>> Add(BookCreateModel book);
    Task<ResultViewModel> Update(BookUpdateModel book);
    Task<ResultViewModel> Delete(Guid id);
    Task<ResultViewModel> Available(Guid id);
    Task<ResultViewModel> Archive(Guid id);
}