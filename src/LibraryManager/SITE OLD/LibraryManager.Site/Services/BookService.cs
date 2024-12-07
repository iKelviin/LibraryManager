using LibraryManager.Site.Models;
using LibraryManager.Site.Repositories.Interfaces;
using LibraryManager.Site.Services.Interfaces;

namespace LibraryManager.Site.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<BookViewModel>>> GetAllBooks()
    {
       var books = await _repository.GetAllBooks();
       if (books is null) return ResultViewModel<List<BookViewModel>>.Error("Books not found.");
       return ResultViewModel<List<BookViewModel>>.Success(books);
    }

    public async Task<ResultViewModel<BookViewModel>> GetBookById(Guid id)
    {
        var book = await _repository.GetBookById(id);
        if (book is null) return ResultViewModel<BookViewModel>.Error("Book not found.");
        return ResultViewModel<BookViewModel>.Success(book);
    }
}