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

    public async Task<ResultViewModel<List<BookViewModel>>> GetAllBooks(string searchWord)
    {
       var books = await _repository.GetAllBooks();
       if (books is null) return ResultViewModel<List<BookViewModel>>.Error("Books not found.");

       if (!string.IsNullOrEmpty(searchWord))
       {
           books = books.FindAll(x=> x.Title.ToLower().Contains(searchWord.ToLower()) ||
                                     x.Author.ToLower().Contains(searchWord.ToLower()));
       }
       
       return ResultViewModel<List<BookViewModel>>.Success(books);
    }

    public async Task<ResultViewModel<BookViewModel>> GetBookById(Guid id)
    {
        var book = await _repository.GetBookById(id);
        if (book is null) return ResultViewModel<BookViewModel>.Error("Book not found.");
        return ResultViewModel<BookViewModel>.Success(book);
    }

    public async Task<ResultViewModel<Guid>> Add(BookViewModel book)
    {
        var guid = await _repository.Add(book);
        if (guid == Guid.Empty) return ResultViewModel<Guid>.Error("Error while adding book.");
        return ResultViewModel<Guid>.Success(guid);
    }
}