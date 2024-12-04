using LibraryManager.Application.Models;
using LibraryManager.Application.Queries.BookQueries.GetByIdBook;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetByIdBook;

public class GetByIdBookHandler : IRequestHandler<GetByIdBookQuery, ResultViewModel<BookDetailsViewModel>>
{
    private readonly IBookRepository _bookRepository;

    public GetByIdBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ResultViewModel<BookDetailsViewModel>> Handle(GetByIdBookQuery request,
        CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null) return ResultViewModel<BookDetailsViewModel>.Error("Book not found.");

        var model = BookDetailsViewModel.FromEntity(book);

        return ResultViewModel<BookDetailsViewModel>.Success(model);
    }
}