using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.InsertBook;

public class InsertBookHandler(IBookRepository bookRepository)
    : IRequestHandler<InsertBookCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();
        await bookRepository.AddAsync(book);
        
        return ResultViewModel<Guid>.Success(book.Id);
    }
}