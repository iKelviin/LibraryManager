using LibraryManager.Site.Models;

namespace LibraryManager.Site.Repositories.Interfaces;

public interface IBookRepository
{
    Task <ResultViewModel<List<BookViewModel>>> GetAllBooks();
    Task<ResultViewModel<BookViewModel>> GetBookById(Guid id);
    Task<ResultViewModel<Guid>> Add(BookCreateModel book);
    Task<ResultViewModel> Update(BookUpdateModel book);
    Task<ResultViewModel> Delete(Guid id);
}