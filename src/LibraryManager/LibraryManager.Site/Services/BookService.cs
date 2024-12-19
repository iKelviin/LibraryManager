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
       var result = await _repository.GetAllBooks();
       if(!result.IsSucces) return ResultViewModel<List<BookViewModel>>.Error(result.Message);

       var books = result.Data!;
       if (!string.IsNullOrEmpty(searchWord))
       {
           books = books.FindAll(x=> x.Title.ToLower().Contains(searchWord.ToLower()) ||
                                     x.Author.ToLower().Contains(searchWord.ToLower()));
       }
       
       return ResultViewModel<List<BookViewModel>>.Success(books);
    }

    public async Task<ResultViewModel<BookViewModel>> GetBookById(Guid id)
    {
        return await _repository.GetBookById(id);
    }

    public async Task<ResultViewModel<Guid>> Add(BookCreateModel book)
    {
        return await _repository.Add(book);
    }

    public async Task<ResultViewModel> Update(BookUpdateModel book)
    {
        return await _repository.Update(book); 
    }

    public async Task<ResultViewModel> Delete(Guid id)
    {
        return await _repository.Delete(id);
    }
    
    public async Task<ResultViewModel> Archive(Guid id)
    {
        return await _repository.Archive(id);
    }
    
    public async Task<ResultViewModel> Available(Guid id)
    {
        return await _repository.Available(id);
    }
}