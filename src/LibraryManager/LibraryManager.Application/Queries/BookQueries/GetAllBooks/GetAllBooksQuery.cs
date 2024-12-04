using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetAllBooks;

public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookViewModel>>>
{
    
}